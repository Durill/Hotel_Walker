using Hotel_Walker.Data;
using Hotel_Walker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hotel_Walker.Controllers.Admin
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdminReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminReservationsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IdentityUser ussr = await _userManager.FindByIdAsync("c64fe004-2784-4733-bc9f-5afddb458225");
            Console.WriteLine(ussr.UserName);
            ViewBag.Reservations = _context.Reservation.Select(reservation => new
            {
                id = reservation.Id,
                room = _context.Room.Where(room => room.Id == reservation.RoomId).Select(room => room.RoomName).FirstOrDefault().ToString(),
                arrivalDate = reservation.ArrivalDate.ToShortDateString(),
                departureDate = reservation.DepartureDate.ToShortDateString(),
                price = (int?)_context.Room.Where(room => room.Id == reservation.RoomId).Select(room => room.Price * reservation.PaidDays).FirstOrDefault(),
                status = reservation.Status,
                user = _userManager.FindByIdAsync(reservation.User.Id).Result,
                isAccepted = reservation.IsAccepted,
                isCancelled = reservation.IsCancelled
            });
            return View();
        }

        public async Task<IActionResult> Confirm(int? id)
        {
            var reservation = _context.Reservation.Where(reservation => reservation.Id == id).FirstOrDefault();
            if (reservation == null)
            {
                return NotFound();
            }
            reservation.IsAccepted = true;
            reservation.Status = "Confirmed";
            if (ModelState.IsValid)
            {
                _context.Update(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
