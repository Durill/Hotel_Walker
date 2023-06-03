# Dokumentacja projektu Hotel Walker

# Spis treści
* [Opis aplikacji](#opis-aplikacji)
* [Technologie](#technologie)
* [Diagram przypadków użycia](#diagram-przypadków-użycia)
* [Diagram klas](#diagram-klas)
* [Instalacja](#instalacja)
* [Autor](#autor)


## Opis aplikacji
Celem aplikacji internetowej jest skupienie bieżących ofert pokoi do wynajęcia w Hotelu Walker. Użytkownik po zarejestrowaniu i zalogowaniu będzie w stanie znaleźć oraz zarezerwować pokój w wybranym przez siebie terminie.
Użytkownik będzie również w stanie sprawdzić status swojej rezerwacji, odwołać ją jeśli nie została jeszcze zatwierdzona przez administratora oraz edytować swoje dane. Administrator aplikacji będzie miał możliwość dodawania/usuwania pokoi oraz podglądu i zatwierdzania/anulowania rezerwacji.

## Technologie
Aplikacja została zrealizowana w architekturze klient-serwer w oparciu o wzorzec MVC (Model-View-Controller). Wykorzystana została technologia ASP.NET 6 wraz z bazą MSSQL. Cała aplikacja została zdeployowana na usłudzie hostingowej Azure oraz jako backup SmarterASP.NET

## Diagram przypadków użycia
![przypadki_użycia_REZERWACJA drawio (5)](https://github.com/Durill/Hotel_Walker/assets/70134706/2e409dcf-a04b-441f-9e4d-7101ae7e1da0)

## Diagram klas
![Diagram_klas_Hotel_Walker_dark drawio](https://github.com/Durill/Hotel_Walker/assets/70134706/26bc6ce2-31c0-42a3-b089-ebe234b73b8d)

## Instalacja
Jeśli chcesz wypróbować aplikację lokalnie, wystarczy ściągnąc repozytorium uruchomić je w programie Microsoft Visual Studio.
Następnie w konsoli menadżera pakietów NuGet wykonać poniższą komendę
```
update-database
```
Teraz można bez przeszkód uruchomić projekt lokalnie

## Autor
Wojciech Batorski
