using Hotel_Walker.Data;
using Hotel_Walker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Walker.Controllers.User
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReservationsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChooseDate([Bind("Id, ArrivalDate, DepartureDate")] ReservationDTO reservationDTO)
        {
            return RedirectToAction("ChooseRoom", reservationDTO);
        }

        // GET: ChooseRoom
        public async Task<IActionResult> ChooseRoom(ReservationDTO reservationDTO)
        {
            ViewBag.ArrivalDate = reservationDTO.ArrivalDate;
            ViewBag.DepartureDate = reservationDTO.DepartureDate;

            var takenRooms = _context.Reservation
                .Where(reservation => !reservation.IsCancelled &&
                    ((reservationDTO.ArrivalDate <= reservation.ArrivalDate && reservationDTO.DepartureDate >= reservation.ArrivalDate)
                    || (reservationDTO.ArrivalDate <= reservation.DepartureDate && reservationDTO.DepartureDate >= reservation.DepartureDate)
                    || (reservationDTO.ArrivalDate >= reservation.ArrivalDate && reservationDTO.DepartureDate <= reservation.DepartureDate)))
                .Select(reservation => reservation.RoomId)
                .Distinct()
                .ToList();
            foreach (var room in takenRooms)
            {
                Console.WriteLine(room);
            }

            var freeRooms = _context.Room
                .Where(room => !takenRooms.Contains(room.Id) && room.IsActive)
                .ToList();

            return View(freeRooms);
        }

        // POST: BookARoom
        public async Task<IActionResult> BookARoom(int roomId, DateTime arrivalDate, DateTime departureDate)
        {
            IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            TimeSpan timeSpan = departureDate - arrivalDate;
            int paidDays = timeSpan.Days;
            Reservation reservation = new Reservation();
            reservation.RoomId = roomId;
            reservation.UserId = user.Id;
            reservation.ArrivalDate = arrivalDate;
            reservation.DepartureDate = departureDate;
            reservation.PaidDays = paidDays;
            reservation.Status = "Pending";
            reservation.IsAccepted = false;
            reservation.IsCancelled = false;
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("MyReservations");
            }
            return RedirectToAction("MyReservations");
        }

        public async Task<IActionResult> MyReservations()
        {
            IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserReservation = _context.Reservation
                .Where(reservation => reservation.User == user)
                .Select(reservation => new
            {
                id = reservation.Id,
                room = _context.Room.Where(room => room.Id == reservation.RoomId).Select(room => room.RoomName).FirstOrDefault().ToString(),
                arrivalDate = reservation.ArrivalDate.ToShortDateString(),
                departureDate = reservation.DepartureDate.ToShortDateString(),
                price = (int?)_context.Room.Where(room => room.Id == reservation.RoomId).Select(room => room.Price * reservation.PaidDays).FirstOrDefault(),
                status = reservation.Status
            }).ToList();
            return View();
        }

        public async Task<IActionResult> Decline(int? id)
        {
            var reservation = _context.Reservation.Where(reservation => reservation.Id == id).FirstOrDefault();
            if (reservation == null)
            {
                return NotFound();
            }
            reservation.IsCancelled = true;
            reservation.Status = "Declined";
            if (ModelState.IsValid)
            {
                _context.Update(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("MyReservations");
            }
            return RedirectToAction("MyReservations");
        }
    }
}
