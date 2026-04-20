# BarbershopAPI

## Deskripsi
BarbershopAPI adalah REST API sederhana untuk mengelola data barbershop seperti user, barber, dan booking. API ini mendukung operasi CRUD serta relasi antar tabel menggunakan database PostgreSQL.

## Teknologi
1. Bahasa: C#
2. Framework: ASP.NET Core Web API
3. Database: PostgreSQL
4. Library: Npgsql

## Cara Menjalankan
1. Clone repository
2. Buka project di Visual Studio
3. Pastikan PostgreSQL sudah aktif
4. Jalankan project (F5 / Run)
5. Buka Swagger:
    https://localhost:7289/swagger/index.html

## Cara Import Database
1. Buka pgAdmin / psql
2. Buat database:
   CREATE DATABASE barbershop;
3. Jalankan file:
   database.sql
4. Pastikan tabel dan data berhasil dibuat

## Struktur Project
BarbershopAPI/ 
├── Context/ 
├── Controllers/ 
├── Helpers/
├── Models/ 
├── appssettings.json/
├── database.sql 
├── README.md

## Struktur Database
Users
- id_user (PK)
- nama
- email
- password
- created_at
- updated_at
- deleted_at

Barbers
- id_barber (PK)
- nama
- spesialis
- created_at
- updated_at

Bookings
- id_booking (PK)
- user_id (FK)
- barber_id (FK)
- tanggal
- jam
- created_at
- updated_at

## Endpoint
| Method | URL | Keterangan |
|--------|-----|------------|
| GET | /api/user | Ambil semua user |
| GET | /api/user/{id} | Ambil user by id |
| POST | /api/user | Tambah user |
| PUT | /api/user/{id} | Update user |
| DELETE | /api/user/{id} | Hapus user (soft delete) |
| GET | /api/booking | Ambil data booking (JOIN) |
| POST | /api/booking | Tambah booking |
| GET | /api/barber | Ambil data barber |

## Format Respons
Succes :
|{|
|  "status": "success",|
|  "data": {...}|
|}|

Error
|{|
|  "status": "error",|
|  "message": "Pesan error"|
|}|

## Skenario Error
- GET user dengan ID tidak ditemukan → 404  
- POST email sudah digunakan → 400  
- POST input tidak valid → 400  
- PUT user tidak ditemukan → 404  
- DELETE user tidak ditemukan / sudah dihapus → 404  

## Identitas
Nama    : Rofiqoh Adawiyah
NIM     : 242410102008
Kelas   : PAA A