-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 25, 2016 at 06:56 AM
-- Server version: 10.1.10-MariaDB
-- PHP Version: 7.0.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ag_dbs`
--

-- --------------------------------------------------------

--
-- Table structure for table `friends`
--

CREATE TABLE `friends` (
  `A` varchar(200) DEFAULT NULL,
  `B` varchar(200) DEFAULT NULL,
  `starttime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `closeness` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `friends`
--

INSERT INTO `friends` (`A`, `B`, `starttime`, `closeness`) VALUES
('sdf', 'asc', '2016-04-24 18:57:24', 0),
('bhargav123', 'safjk', '2016-04-25 03:25:07', 3.33333),
('chiyochichi', 'sadjh', '2016-04-25 04:47:30', 8.33333);

--
-- Triggers `friends`
--
DELIMITER $$
CREATE TRIGGER `myTrig4` BEFORE INSERT ON `friends` FOR EACH ROW begin 
	insert into suggestions(A,B,Weight) select new.A,B,20 from friends where A = new.B;        
end
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE `groups` (
  `groupid` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `interest`
--

CREATE TABLE `interest` (
  `INTERESTid` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `interest`
--

INSERT INTO `interest` (`INTERESTid`, `name`, `description`) VALUES
(0, 'playing', 'uiasdfhuasldh'),
(1, 'dancing', 'iakfjsifjsdiofj');

-- --------------------------------------------------------

--
-- Table structure for table `likes`
--

CREATE TABLE `likes` (
  `personid` varchar(200) DEFAULT NULL,
  `INTERESTid` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `likes`
--

INSERT INTO `likes` (`personid`, `INTERESTid`) VALUES
('asc', 0),
('bhargav123', 0);

--
-- Triggers `likes`
--
DELIMITER $$
CREATE TRIGGER `myTrig2` BEFORE INSERT ON `likes` FOR EACH ROW BEGIN
	insert into suggestions(A,B,Weight) select new.personid,personid,20 from likes where interestid = new.interestid;    
end
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `membership`
--

CREATE TABLE `membership` (
  `personID` varchar(200) DEFAULT NULL,
  `groupid` int(11) DEFAULT NULL,
  `starttime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `endtime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Triggers `membership`
--
DELIMITER $$
CREATE TRIGGER `myTrig1` BEFORE INSERT ON `membership` FOR EACH ROW BEGIN
	insert into suggestions(A,B,Weight) select new.personid,personid,5 from groups where groupid = new.groupid;    
end
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `person`
--

CREATE TABLE `person` (
  `personID` varchar(200) NOT NULL,
  `name` varchar(100) NOT NULL,
  `emailid` varchar(100) DEFAULT NULL,
  `gender` char(1) NOT NULL,
  `dob` date NOT NULL,
  `locality` int(11) DEFAULT NULL,
  `workplace` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `person`
--

INSERT INTO `person` (`personID`, `name`, `emailid`, `gender`, `dob`, `locality`, `workplace`) VALUES
('asc', '', 'asc@gmail.com', 'M', '1997-07-05', 2, 1),
('bhargav123', 'bhargav', 'hargav@gail.com', 'M', '1994-05-06', 2, 1),
('bhargavkaranam', '', 'bhargav@iecse.xyz', 'M', '1996-10-22', 2, 1),
('chiyochichi', 'Chiyo', 'chiyo@example.com', 'M', '1996-06-07', 2, 1),
('dankswagmaster', 'Lucita', 'geg@example.com', 'O', '1995-05-11', 1, 2),
('dsjih', '', 'ehdj@gmail.com', 'M', '1996-06-07', 2, 1),
('dsjih2', '', 'ehdj@gmail.com', 'M', '1996-06-07', 2, 1),
('ishitabedi', 'Ishita Bedi', 'test@gmail.com', 'F', '1997-10-08', 2, 1),
('Katoch', 'Anirudh Katoch', 'katoch.anirudh@gmail.com', 'M', '1996-08-08', 2, 1),
('kotich', '', 'katoch.anirudh@gmail.com', 'M', '1995-10-08', 2, 1),
('lakalaka', 'bhargav', 'bhargav.karanam@gmail.com', 'M', '1995-07-07', 2, 1),
('sadjh', 'asudjh', 'asdhj@gmail.com', 'M', '1996-08-06', 2, 1),
('safjk', '', 'bhargav.karanam@gmail.com', 'M', '1999-06-06', 2, 1),
('sanchit', 'Sanchit', 'sanchit@gmail.com', 'M', '1995-06-07', 1, 2),
('sdf', '', 'edf@gmail.com', 'M', '1995-04-07', 2, 1),
('sdfjk', '', 'sdifj@gmail.com', 'M', '2000-08-27', 2, 1),
('sduajkh', 'saudjkhc', 'sdijh@gmail.com', 'M', '1996-05-04', 2, 1),
('sfadijhk', '', 'dfusjh@gmail.com', 'M', '1995-05-09', 2, 1),
('sjadh', '', 'bhargav.karanam@gmail.com', 'M', '1996-06-06', 2, 1),
('uwejhu', '', 'bhargav.karanam@gmail.com', 'M', '1992-04-05', 2, 1);

--
-- Triggers `person`
--
DELIMITER $$
CREATE TRIGGER `myTrig` BEFORE INSERT ON `person` FOR EACH ROW BEGIN
	insert into suggestions(A,B,Weight) select new.personid,personid,10 from person where locality = new.locality;    
   insert into suggestions(A,B,Weight) select new.personid,personid,10 from person where workplace = new.workplace;
end
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `photo`
--

CREATE TABLE `photo` (
  `photoid` int(11) NOT NULL,
  `taken_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `url` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `photo`
--

INSERT INTO `photo` (`photoid`, `taken_at`, `url`) VALUES
(5261, '2016-04-25 04:14:40', 'vlcsnap-2015-11-30-21h58m37s350.png'),
(7301, '2016-04-25 04:42:40', 'vlcsnap-2015-11-30-21h58m37s350.png'),
(7418, '2016-04-25 04:38:26', 'vlcsnap-2015-11-30-21h58m37s350.png'),
(7769, '2016-04-25 04:46:22', 'vlcsnap-2015-11-30-21h58m37s350.png');

-- --------------------------------------------------------

--
-- Table structure for table `place`
--

CREATE TABLE `place` (
  `placeID` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `place`
--

INSERT INTO `place` (`placeID`, `name`) VALUES
(1, 'Manipal'),
(2, 'Hyderabad'),
(3, 'Food Court');

-- --------------------------------------------------------

--
-- Table structure for table `suggestions`
--

CREATE TABLE `suggestions` (
  `id` int(10) NOT NULL,
  `A` varchar(100) NOT NULL,
  `B` varchar(100) NOT NULL,
  `Weight` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `suggestions`
--

INSERT INTO `suggestions` (`id`, `A`, `B`, `Weight`) VALUES
(1, 'lakalaka', 'asc', 0),
(2, 'lakalaka', 'bhargavkaranam', 0),
(3, 'lakalaka', 'dsjih', 0),
(4, 'lakalaka', 'dsjih2', 0),
(5, 'lakalaka', 'kotich', 0),
(6, 'lakalaka', 'lakalaka', 0),
(7, 'lakalaka', 'safjk', 0),
(8, 'lakalaka', 'sdf', 0),
(9, 'lakalaka', 'sdfjk', 0),
(10, 'lakalaka', 'sfadijhk', 0),
(11, 'lakalaka', 'sjadh', 0),
(12, 'lakalaka', 'uwejhu', 0),
(16, 'lakalaka', 'asc', 0),
(17, 'lakalaka', 'bhargavkaranam', 0),
(18, 'lakalaka', 'dsjih', 0),
(19, 'lakalaka', 'dsjih2', 0),
(20, 'lakalaka', 'kotich', 0),
(21, 'lakalaka', 'lakalaka', 0),
(22, 'lakalaka', 'safjk', 0),
(23, 'lakalaka', 'sdf', 0),
(24, 'lakalaka', 'sdfjk', 0),
(25, 'lakalaka', 'sfadijhk', 0),
(26, 'lakalaka', 'sjadh', 0),
(27, 'lakalaka', 'uwejhu', 0),
(31, 'sduajkh', 'asc', 0),
(32, 'sduajkh', 'bhargavkaranam', 0),
(33, 'sduajkh', 'dsjih', 0),
(34, 'sduajkh', 'dsjih2', 0),
(35, 'sduajkh', 'kotich', 0),
(36, 'sduajkh', 'lakalaka', 0),
(37, 'sduajkh', 'safjk', 0),
(38, 'sduajkh', 'sdf', 0),
(39, 'sduajkh', 'sdfjk', 0),
(40, 'sduajkh', 'sduajkh', 0),
(41, 'sduajkh', 'sfadijhk', 0),
(42, 'sduajkh', 'sjadh', 0),
(43, 'sduajkh', 'uwejhu', 0),
(46, 'sduajkh', 'asc', 0),
(47, 'sduajkh', 'bhargavkaranam', 0),
(48, 'sduajkh', 'dsjih', 0),
(49, 'sduajkh', 'dsjih2', 0),
(50, 'sduajkh', 'kotich', 0),
(51, 'sduajkh', 'lakalaka', 0),
(52, 'sduajkh', 'safjk', 0),
(53, 'sduajkh', 'sdf', 0),
(54, 'sduajkh', 'sdfjk', 0),
(55, 'sduajkh', 'sduajkh', 0),
(56, 'sduajkh', 'sfadijhk', 0),
(57, 'sduajkh', 'sjadh', 0),
(58, 'sduajkh', 'uwejhu', 0),
(61, 'sduajkh', 'bhargavkaranam', 0),
(62, 'sadjh', 'asc', 0),
(63, 'sadjh', 'bhargavkaranam', 0),
(64, 'sadjh', 'dsjih', 0),
(65, 'sadjh', 'dsjih2', 0),
(66, 'sadjh', 'kotich', 0),
(67, 'sadjh', 'lakalaka', 0),
(68, 'sadjh', 'sadjh', 0),
(69, 'sadjh', 'safjk', 0),
(70, 'sadjh', 'sdf', 0),
(71, 'sadjh', 'sdfjk', 0),
(72, 'sadjh', 'sduajkh', 0),
(73, 'sadjh', 'sfadijhk', 0),
(74, 'sadjh', 'sjadh', 0),
(75, 'sadjh', 'uwejhu', 0),
(77, 'sadjh', 'asc', 0),
(78, 'sadjh', 'bhargavkaranam', 0),
(79, 'sadjh', 'dsjih', 0),
(80, 'sadjh', 'dsjih2', 0),
(81, 'sadjh', 'kotich', 0),
(82, 'sadjh', 'lakalaka', 0),
(83, 'sadjh', 'sadjh', 0),
(84, 'sadjh', 'safjk', 0),
(85, 'sadjh', 'sdf', 0),
(86, 'sadjh', 'sdfjk', 0),
(87, 'sadjh', 'sduajkh', 0),
(88, 'sadjh', 'sfadijhk', 0),
(89, 'sadjh', 'sjadh', 0),
(90, 'sadjh', 'uwejhu', 0),
(92, 'ishitabedi', 'asc', 10),
(93, 'ishitabedi', 'bhargavkaranam', 10),
(94, 'ishitabedi', 'dsjih', 10),
(95, 'ishitabedi', 'dsjih2', 10),
(96, 'ishitabedi', 'kotich', 10),
(97, 'ishitabedi', 'lakalaka', 10),
(98, 'ishitabedi', 'sadjh', 10),
(99, 'ishitabedi', 'safjk', 10),
(100, 'ishitabedi', 'sdf', 10),
(101, 'ishitabedi', 'sdfjk', 10),
(102, 'ishitabedi', 'sduajkh', 10),
(103, 'ishitabedi', 'sfadijhk', 10),
(104, 'ishitabedi', 'sjadh', 10),
(105, 'ishitabedi', 'uwejhu', 10),
(107, 'ishitabedi', 'asc', 10),
(108, 'ishitabedi', 'bhargavkaranam', 10),
(109, 'ishitabedi', 'dsjih', 10),
(110, 'ishitabedi', 'dsjih2', 10),
(111, 'ishitabedi', 'kotich', 10),
(112, 'ishitabedi', 'lakalaka', 10),
(113, 'ishitabedi', 'sadjh', 10),
(114, 'ishitabedi', 'safjk', 10),
(115, 'ishitabedi', 'sdf', 10),
(116, 'ishitabedi', 'sdfjk', 10),
(117, 'ishitabedi', 'sduajkh', 10),
(118, 'ishitabedi', 'sfadijhk', 10),
(119, 'ishitabedi', 'sjadh', 10),
(120, 'ishitabedi', 'uwejhu', 10),
(122, 'Katoch', 'asc', 10),
(123, 'Katoch', 'bhargavkaranam', 10),
(124, 'Katoch', 'dsjih', 10),
(125, 'Katoch', 'dsjih2', 10),
(126, 'Katoch', 'ishitabedi', 10),
(127, 'Katoch', 'kotich', 10),
(128, 'Katoch', 'lakalaka', 10),
(129, 'Katoch', 'sadjh', 10),
(130, 'Katoch', 'safjk', 10),
(131, 'Katoch', 'sdf', 10),
(132, 'Katoch', 'sdfjk', 10),
(133, 'Katoch', 'sduajkh', 10),
(134, 'Katoch', 'sfadijhk', 10),
(135, 'Katoch', 'sjadh', 10),
(136, 'Katoch', 'uwejhu', 10),
(137, 'Katoch', 'asc', 10),
(138, 'Katoch', 'bhargavkaranam', 10),
(139, 'Katoch', 'dsjih', 10),
(140, 'Katoch', 'dsjih2', 10),
(141, 'Katoch', 'ishitabedi', 10),
(142, 'Katoch', 'kotich', 10),
(143, 'Katoch', 'lakalaka', 10),
(144, 'Katoch', 'sadjh', 10),
(145, 'Katoch', 'safjk', 10),
(146, 'Katoch', 'sdf', 10),
(147, 'Katoch', 'sdfjk', 10),
(148, 'Katoch', 'sduajkh', 10),
(149, 'Katoch', 'sfadijhk', 10),
(150, 'Katoch', 'sjadh', 10),
(151, 'Katoch', 'uwejhu', 10),
(154, 'bhargav123', 'dsjih', 10),
(155, 'bhargav123', 'dsjih2', 10),
(156, 'bhargav123', 'ishitabedi', 10),
(157, 'bhargav123', 'Katoch', 10),
(158, 'bhargav123', 'kotich', 10),
(159, 'bhargav123', 'lakalaka', 10),
(161, 'bhargav123', 'safjk', 10),
(163, 'bhargav123', 'sdfjk', 10),
(164, 'bhargav123', 'sduajkh', 10),
(165, 'bhargav123', 'sfadijhk', 10),
(166, 'bhargav123', 'sjadh', 10),
(167, 'bhargav123', 'uwejhu', 10),
(185, 'bhargav123', 'dsjih', 10),
(186, 'bhargav123', 'dsjih2', 10),
(187, 'bhargav123', 'ishitabedi', 10),
(188, 'bhargav123', 'Katoch', 10),
(189, 'bhargav123', 'kotich', 10),
(190, 'bhargav123', 'lakalaka', 10),
(192, 'bhargav123', 'safjk', 10),
(194, 'bhargav123', 'sdfjk', 10),
(195, 'bhargav123', 'sduajkh', 10),
(196, 'bhargav123', 'sfadijhk', 10),
(197, 'bhargav123', 'sjadh', 10),
(198, 'bhargav123', 'uwejhu', 10),
(214, 'bhargav123', 'asc', 20),
(215, 'anirudh', 'bhargav', 30),
(216, 'qwerty', 'bhargav', 30),
(217, 'qwerty', 'anirudh', 30),
(219, 'sanchit', 'dankswagmaster', 10),
(220, 'sanchit', 'dankswagmaster', 10),
(221, 'dankswagmaster', 'sanchit', 30),
(222, 'bhargav', 'sanchit', 30),
(223, 'bhargav', 'dankswagmaster', 30),
(226, 'chiyochichi', 'bhargav123', 10),
(227, 'chiyochichi', 'bhargavkaranam', 10),
(228, 'chiyochichi', 'dsjih', 10),
(229, 'chiyochichi', 'dsjih2', 10),
(230, 'chiyochichi', 'ishitabedi', 10),
(231, 'chiyochichi', 'Katoch', 10),
(232, 'chiyochichi', 'kotich', 10),
(233, 'chiyochichi', 'lakalaka', 10),
(234, 'chiyochichi', 'sadjh', 10),
(235, 'chiyochichi', 'safjk', 10),
(236, 'chiyochichi', 'sdf', 10),
(237, 'chiyochichi', 'sdfjk', 10),
(238, 'chiyochichi', 'sduajkh', 10),
(239, 'chiyochichi', 'sfadijhk', 10),
(240, 'chiyochichi', 'sjadh', 10),
(241, 'chiyochichi', 'uwejhu', 10),
(257, 'chiyochichi', 'bhargav123', 10),
(258, 'chiyochichi', 'bhargavkaranam', 10),
(259, 'chiyochichi', 'dsjih', 10),
(260, 'chiyochichi', 'dsjih2', 10),
(261, 'chiyochichi', 'ishitabedi', 10),
(262, 'chiyochichi', 'Katoch', 10),
(263, 'chiyochichi', 'kotich', 10),
(264, 'chiyochichi', 'lakalaka', 10),
(265, 'chiyochichi', 'sadjh', 10),
(266, 'chiyochichi', 'safjk', 10),
(267, 'chiyochichi', 'sdf', 10),
(268, 'chiyochichi', 'sdfjk', 10),
(269, 'chiyochichi', 'sduajkh', 10),
(270, 'chiyochichi', 'sfadijhk', 10),
(271, 'chiyochichi', 'sjadh', 10),
(272, 'chiyochichi', 'uwejhu', 10),
(287, 'sadjh', 'chiyochichi', 30),
(288, 'chiyochichi', 'sadjh', 30),
(289, 'asc', 'chiyochichi', 30),
(290, 'asc', 'sadjh', 30),
(293, 'sadjh', 'asc', 30),
(295, 'uwejhu', 'chiyochichi', 30),
(296, 'uwejhu', 'sadjh', 30),
(297, 'uwejhu', 'asc', 30),
(298, 'chiyochichi', 'uwejhu', 30),
(299, 'sadjh', 'uwejhu', 30),
(300, 'asc', 'uwejhu', 30);

-- --------------------------------------------------------

--
-- Table structure for table `tagged`
--

CREATE TABLE `tagged` (
  `personid` varchar(200) DEFAULT NULL,
  `photoid` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tagged`
--

INSERT INTO `tagged` (`personid`, `photoid`) VALUES
('bhargav', 5261),
('katoch', 5261),
('test', 5261),
('bhargav', 7418),
('anirudh', 7418),
('qwerty', 7418),
('sanchit', 7301),
('dankswagmaster', 7301),
('bhargav', 7301),
('chiyochichi', 7769),
('sadjh', 7769),
('asc', 7769),
('uwejhu', 7769);

--
-- Triggers `tagged`
--
DELIMITER $$
CREATE TRIGGER `myTrig5` AFTER INSERT ON `tagged` FOR EACH ROW begin
	insert into suggestions(A,B,Weight) select new.personID, personID, 30 from tagged where photoid = new.photoid and personid <> new.personid;
	insert into suggestions(B,A,Weight) select new.personID, personID, 30 from tagged where photoid = new.photoid and personid <> new.personid;
end
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `visited`
--

CREATE TABLE `visited` (
  `personid` varchar(200) DEFAULT NULL,
  `placeid` int(11) DEFAULT NULL,
  `visited` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `visited`
--

INSERT INTO `visited` (`personid`, `placeid`, `visited`) VALUES
('bhargavkaranam', 1, '2016-04-24 02:50:10'),
('sduajkh', 1, '2016-04-25 00:44:21'),
('sduajkh', 3, '2016-04-25 00:45:31');

--
-- Triggers `visited`
--
DELIMITER $$
CREATE TRIGGER `myTrig3` BEFORE INSERT ON `visited` FOR EACH ROW BEGIN
	insert into suggestions(A,B,Weight) select new.personid,personid,5 from visited where placeid = new.placeid;        
end
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `worked`
--

CREATE TABLE `worked` (
  `personid` varchar(200) DEFAULT NULL,
  `placeid` int(11) DEFAULT NULL,
  `starttime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `endtime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`groupid`);

--
-- Indexes for table `interest`
--
ALTER TABLE `interest`
  ADD PRIMARY KEY (`INTERESTid`);

--
-- Indexes for table `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`personID`);

--
-- Indexes for table `photo`
--
ALTER TABLE `photo`
  ADD PRIMARY KEY (`photoid`);

--
-- Indexes for table `place`
--
ALTER TABLE `place`
  ADD PRIMARY KEY (`placeID`);

--
-- Indexes for table `suggestions`
--
ALTER TABLE `suggestions`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `place`
--
ALTER TABLE `place`
  MODIFY `placeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `suggestions`
--
ALTER TABLE `suggestions`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=301;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
