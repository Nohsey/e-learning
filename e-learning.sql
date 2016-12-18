-- phpMyAdmin SQL Dump
-- version 4.5.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Gegenereerd op: 18 dec 2016 om 10:21
-- Serverversie: 5.7.11
-- PHP-versie: 5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `e-learning`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `antwoorden`
--

CREATE TABLE `antwoorden` (
  `AntwoordID` int(10) NOT NULL COMMENT 'Antwoord id',
  `VraagID` int(10) NOT NULL COMMENT 'Vraag id',
  `Antwoord` varchar(32) NOT NULL COMMENT 'Het antwoord',
  `Goed_Fout` tinyint(1) NOT NULL COMMENT 'Goed/Fout'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `les`
--

CREATE TABLE `les` (
  `LesID` int(11) NOT NULL COMMENT 'Les id',
  `Uitleg` text NOT NULL COMMENT 'Uitleg van de les',
  `LesonderwerpID` int(10) NOT NULL COMMENT 'Lesonderwerp id',
  `lesNaam` varchar(32) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `les`
--

INSERT INTO `les` (`LesID`, `Uitleg`, `LesonderwerpID`, `lesNaam`) VALUES
(1, '...', 26, 'Farm Animals'),
(2, '...', 26, 'Jungle Animals'),
(3, '...', 26, 'Pets'),
(4, '...', 1, 'Verliefde getallen'),
(5, '...', 20, 'Jagers'),
(6, '...', 1, 'Tientallen'),
(7, '...', 28, 'Body parts'),
(8, '...', 22, 'Zeedieren'),
(9, '...', 22, 'Roofdieren'),
(10, '...', 22, 'Vliegende dieren'),
(11, '...', 28, 'My Face'),
(12, '...', 15, 'Stam'),
(13, '...', 15, 'Stam +t'),
(14, '...', 15, 'Verleden tijd'),
(15, '...', 21, 'Gezicht'),
(16, '...', 21, 'Organen'),
(17, '', 22, 'Insecten');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `lesonderwerp`
--

CREATE TABLE `lesonderwerp` (
  `LesonderwerpID` int(10) NOT NULL COMMENT 'Lesonderwerp id',
  `LesOmschrijving` varchar(32) NOT NULL COMMENT 'Omschrijving van lesonderwerp',
  `VakID` int(2) NOT NULL COMMENT 'vak id'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `lesonderwerp`
--

INSERT INTO `lesonderwerp` (`LesonderwerpID`, `LesOmschrijving`, `VakID`) VALUES
(1, 'Optellen', 2),
(3, 'Aftrekken', 2),
(20, 'Boeren en Jagers', 3),
(5, 'Gemengd', 2),
(19, 'Middeleeuwen', 3),
(18, 'Tijdlijnen', 3),
(17, 'Meervoud', 1),
(16, 'Begrijpend lezen', 1),
(15, 'Werkwoorden', 1),
(21, 'Het lichaam', 4),
(22, 'Diersoorten', 4),
(23, 'Planten', 4),
(29, 'Dit is een test', 5),
(26, 'Animals', 5),
(27, 'Colours', 5),
(28, 'My body', 5),
(30, 'Nederlands', 1),
(31, 'did it work?', 1);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rol`
--

CREATE TABLE `rol` (
  `RolID` int(2) NOT NULL COMMENT 'Rol ID',
  `RolOmschrijving` varchar(32) NOT NULL COMMENT 'Omschrijving van rol'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `rol`
--

INSERT INTO `rol` (`RolID`, `RolOmschrijving`) VALUES
(1, 'Leerling'),
(2, 'Admin');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

CREATE TABLE `users` (
  `UserID` int(10) NOT NULL COMMENT 'User ID',
  `Username` varchar(32) NOT NULL COMMENT 'Gebruikersnaam',
  `Password` varchar(32) NOT NULL COMMENT 'Wachtwoord',
  `Voornaam` varchar(32) NOT NULL COMMENT 'Voornaam',
  `Achternaam` varchar(32) NOT NULL COMMENT 'Achternaam',
  `RolID` int(5) NOT NULL COMMENT 'Rol ID'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`UserID`, `Username`, `Password`, `Voornaam`, `Achternaam`, `RolID`) VALUES
(1, 'Nosey', '123', 'Michelle', 'Broens', 2),
(2, 'Leerling', '123', 'Test', 'Gebruiker', 1);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `vak`
--

CREATE TABLE `vak` (
  `VakID` int(5) NOT NULL COMMENT 'Vak ID',
  `Omschrijving` varchar(32) NOT NULL COMMENT 'Omschrijving'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `vak`
--

INSERT INTO `vak` (`VakID`, `Omschrijving`) VALUES
(1, 'Nederlands'),
(2, 'Rekenen'),
(3, 'Geschiedenis'),
(4, 'Biologie'),
(5, 'Engels');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `voortgang`
--

CREATE TABLE `voortgang` (
  `UserID` int(10) NOT NULL,
  `LesID` int(10) NOT NULL,
  `Voortgang` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `vragen`
--

CREATE TABLE `vragen` (
  `VraagID` int(10) NOT NULL,
  `Vraag` text NOT NULL,
  `LesID` int(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `antwoorden`
--
ALTER TABLE `antwoorden`
  ADD PRIMARY KEY (`AntwoordID`);

--
-- Indexen voor tabel `les`
--
ALTER TABLE `les`
  ADD PRIMARY KEY (`LesID`);

--
-- Indexen voor tabel `lesonderwerp`
--
ALTER TABLE `lesonderwerp`
  ADD PRIMARY KEY (`LesonderwerpID`);

--
-- Indexen voor tabel `rol`
--
ALTER TABLE `rol`
  ADD PRIMARY KEY (`RolID`);

--
-- Indexen voor tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`);

--
-- Indexen voor tabel `vak`
--
ALTER TABLE `vak`
  ADD PRIMARY KEY (`VakID`);

--
-- Indexen voor tabel `vragen`
--
ALTER TABLE `vragen`
  ADD PRIMARY KEY (`VraagID`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `antwoorden`
--
ALTER TABLE `antwoorden`
  MODIFY `AntwoordID` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Antwoord id';
--
-- AUTO_INCREMENT voor een tabel `les`
--
ALTER TABLE `les`
  MODIFY `LesID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Les id', AUTO_INCREMENT=18;
--
-- AUTO_INCREMENT voor een tabel `lesonderwerp`
--
ALTER TABLE `lesonderwerp`
  MODIFY `LesonderwerpID` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Lesonderwerp id', AUTO_INCREMENT=32;
--
-- AUTO_INCREMENT voor een tabel `rol`
--
ALTER TABLE `rol`
  MODIFY `RolID` int(2) NOT NULL AUTO_INCREMENT COMMENT 'Rol ID', AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(10) NOT NULL AUTO_INCREMENT COMMENT 'User ID', AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT voor een tabel `vak`
--
ALTER TABLE `vak`
  MODIFY `VakID` int(5) NOT NULL AUTO_INCREMENT COMMENT 'Vak ID', AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT voor een tabel `vragen`
--
ALTER TABLE `vragen`
  MODIFY `VraagID` int(10) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
