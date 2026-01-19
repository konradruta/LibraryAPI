# LibraryAPI – REST API do zarządzania biblioteką

REST API stworzone w **ASP.NET Core**, umożliwiające zarządzanie biblioteką:
książkami, autorami, kategoriami oraz wypożyczeniami, z obsługą kont
użytkowników i autoryzacją JWT.

---

## Funkcjonalności

### Konta użytkowników
- Rejestracja konta użytkownika
- Logowanie użytkownika (JWT)
- Hashowanie haseł (`PasswordHasher`)
- Autoryzacja oparta o role i claims
- Obsługa ról użytkowników (np. Admin / User)

### Biblioteka
- Zarządzanie książkami
- Zarządzanie autorami
- Zarządzanie kategoriami książek
- Wypożyczanie i zwracanie książek
- Relacje: książka – autor – kategoria
- Kontrola dostępności książek

### Bezpieczeństwo
- JWT Authentication
- Autoryzacja oparta o role
- Dane użytkowników zabezpieczone hashami haseł
- Globalna obsługa błędów (middleware)

---

## Architektura projektu

- **Controllers** – endpointy API (Account, Auth, Book, Borrowing, Category, User)
- **Services** – logika biznesowa aplikacji
- **Entities** – encje domenowe oraz `LibraryDbContext`
- **Models** – DTO (request / response)
- **Exceptions** – własne wyjątki aplikacyjne
- **Middleware** – globalna obsługa błędów
- **Migrations** – migracje bazy danych (Entity Framework Core)
- **AuthenticationSettings** – konfiguracja JWT

Projekt oparty o rozdzielenie odpowiedzialności  
(logika biznesowa oddzielona od warstwy API).

---

## Technologie

- ASP.NET Core
- C#
- Entity Framework Core
- JWT Authentication
- PasswordHasher
- Swagger / OpenAPI
- LINQ
- SQL Server

---

## Endpointy

### Account
- POST `/api/account/register` – rejestracja konta użytkownika
- POST `/api/account/login` – logowanie i generowanie tokenu JWT

### Users
- GET `/api/user` – pobranie listy użytkowników
- GET `/api/user/{id}` – pobranie użytkownika po ID
- POST `/api/user` – dodanie nowego użytkownika
- PUT `/api/user/{id}` – edycja użytkownika
- DELETE `/api/user/{id}` – usunięcie użytkownika

### Authors
- GET `/api/author` – pobranie listy autorów
- GET `/api/author/{id}` – pobranie autora po ID
- POST `/api/author` – dodanie nowego autora
- PUT `/api/author/{id}` – edycja autora
- DELETE `/api/author/{id}` – usunięcie autora

### Categories
- GET `/api/category` – pobranie listy kategorii
- GET `/api/category/{id}` – pobranie kategorii po ID
- POST `/api/category` – dodanie nowej kategorii
- PUT `/api/category/{id}` – edycja kategorii
- DELETE `/api/category/{id}` – usunięcie kategorii

### Books
- GET `/api/book` – pobranie listy książek
- GET `/api/book/{id}` – pobranie książki po ID
- POST `/api/book` – dodanie nowej książki
- PUT `/api/book/{id}` – edycja książki
- DELETE `/api/book/{id}` – usunięcie książki

### Borrowings
- GET `/api/borrowing` – pobranie listy wypożyczeń (wymaga autoryzacji)
- GET `/api/borrowing/{id}` – pobranie wypożyczenia po ID (rola Admin)
- POST `/api/borrowing` – utworzenie nowego wypożyczenia
- PUT `/api/borrowing/{id}` – edycja wypożyczenia
- DELETE `/api/borrowing/{id}` – usunięcie wypożyczenia

---

## Uruchomienie projektu

1. Sklonuj repozytorium
2. Skonfiguruj `appsettings.json` (connection string, JWT)
3. Wykonaj migracje bazy danych
4. Uruchom aplikację
5. Otwórz Swagger: https://localhost:5001/swagger

## Cel projektu

Projekt stworzony jako część **portfolio backendowego**,  
w celu nauki oraz prezentacji umiejętności:

- tworzenia REST API w ASP.NET Core
- projektowania relacyjnych modeli danych
- implementacji autoryzacji JWT i ról użytkowników
- pracy z Entity Framework Core
- obsługi logiki biznesowej aplikacji
