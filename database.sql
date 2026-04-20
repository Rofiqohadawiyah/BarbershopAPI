
-- USERS
CREATE TABLE users (
    id_user SERIAL PRIMARY KEY,
    nama VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    deleted_at TIMESTAMP NULL
);


-- BARBERS
CREATE TABLE barbers (
    id_barber SERIAL PRIMARY KEY,
    nama VARCHAR(100) NOT NULL,
    spesialis VARCHAR(100) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


-- BOOKINGS (RELASI)
CREATE TABLE bookings (
    id_booking SERIAL PRIMARY KEY,
    user_id INT NOT NULL,
    barber_id INT NOT NULL,
    tanggal DATE NOT NULL,
    jam TIME NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (user_id) REFERENCES users(id_user),
    FOREIGN KEY (barber_id) REFERENCES barbers(id_barber)
);


-- INDEX (OPTIMASI)
CREATE INDEX idx_users_email ON users(email);
CREATE INDEX idx_bookings_user ON bookings(user_id);
CREATE INDEX idx_bookings_barber ON bookings(barber_id);


-- SAMPLE DATA USERS (10 DATA)
INSERT INTO users (nama, email, password) VALUES
('Ayu', 'ayu@mail.com', '123'),
('Budi', 'budi@mail.com', '123'),
('Citra', 'citra@mail.com', '123'),
('Dodi', 'dodi@mail.com', '123'),
('Eka', 'eka@mail.com', '123'),
('Fina', 'fina@mail.com', '123'),
('Gilang', 'gilang@mail.com', '123'),
('Hana', 'hana@mail.com', '123'),
('Ivan', 'ivan@mail.com', '123'),
('Joko', 'joko@mail.com', '123');


-- SAMPLE DATA BARBERS (8 DATA)
INSERT INTO barbers (nama, spesialis) VALUES
('Rian', 'Fade'),
('Agus', 'Undercut'),
('Deni', 'Pompadour'),
('Rizal', 'Buzzcut'),
('Fajar', 'Taper'),
('Yoga', 'Classic Cut'),
('Rama', 'Mohawk'),
('Ilham', 'Layer');


-- SAMPLE DATA BOOKINGS (12 DATA)
INSERT INTO bookings (user_id, barber_id, tanggal, jam) VALUES
(1,1,'2026-04-20','10:00'),
(2,2,'2026-04-21','11:00'),
(3,3,'2026-04-22','12:00'),
(4,4,'2026-04-23','13:00'),
(5,5,'2026-04-24','14:00'),
(6,1,'2026-04-25','09:00'),
(7,2,'2026-04-26','10:30'),
(8,3,'2026-04-27','11:30'),
(9,4,'2026-04-28','12:30'),
(10,5,'2026-04-29','13:30'),
(1,6,'2026-04-30','14:30'),
(2,7,'2026-05-01','15:00');