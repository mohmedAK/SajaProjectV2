-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 30, 2024 at 11:22 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sajadb`
--

-- --------------------------------------------------------

--
-- Table structure for table `contract`
--

CREATE TABLE `contract` (
  `Id` int(11) NOT NULL,
  `ContractorName` varchar(250) DEFAULT NULL,
  `CompanyName` varchar(250) DEFAULT NULL,
  `StartDate` date DEFAULT NULL,
  `FinishDate` date DEFAULT NULL,
  `Details` text DEFAULT NULL,
  `ProjectIdFk` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `EmpId` int(11) NOT NULL,
  `FName` varchar(100) DEFAULT NULL,
  `LName` varchar(100) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Image` blob DEFAULT NULL,
  `FinalTotal` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


-- --------------------------------------------------------

--
-- Table structure for table `labor_date`
--

CREATE TABLE `labor_date` (
  `Id` int(11) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `LaborType` varchar(250) DEFAULT NULL,
  `Occupation` varchar(250) DEFAULT NULL,
  `Wage` double DEFAULT NULL,
  `ProjectIdFk` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `labor_fallow`
--

CREATE TABLE `labor_fallow` (
  `Id` int(11) NOT NULL,
  `WorkItem` varchar(50) DEFAULT NULL,
  `LaborType` varchar(50) DEFAULT NULL,
  `NumLabor` int(11) DEFAULT NULL,
  `WorkDay` int(11) DEFAULT NULL,
  `CurrentDate` date DEFAULT NULL,
  `ProjectIdFk` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `machine_data`
--

CREATE TABLE `machine_data` (
  `Id` int(11) NOT NULL,
  `MachineName` varchar(50) DEFAULT NULL,
  `MachineNumber` varchar(50) DEFAULT NULL,
  `WageRent` double DEFAULT NULL,
  `WageMaintenance` double DEFAULT NULL,
  `ProjectIdFk` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `machine_fallow`
--

CREATE TABLE `machine_fallow` (
  `Id` int(11) NOT NULL,
  `WorkItem` varchar(50) DEFAULT NULL,
  `MachineName` varchar(50) DEFAULT NULL,
  `Ownership` varchar(50) DEFAULT NULL,
  `RentDays` int(11) DEFAULT NULL,
  `OperationDays` int(11) DEFAULT NULL,
  `CurrentDate` date DEFAULT NULL,
  `ProjectIdFk` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `material_data`
--

CREATE TABLE `material_data` (
  `Id` int(11) NOT NULL,
  `WorkItem` varchar(50) DEFAULT NULL,
  `MaterialName` varchar(50) DEFAULT NULL,
  `PlanningQuantity` int(11) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `Details` text DEFAULT NULL,
  `ProjectIdFk` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `material_fallow`
--

CREATE TABLE `material_fallow` (
  `Id` int(11) NOT NULL,
  `WorkItem` varchar(50) DEFAULT NULL,
  `ActualQuantity` int(11) DEFAULT NULL,
  `CurrentDate` date DEFAULT NULL,
  `ProjectIdFk` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `projects_information`
--

CREATE TABLE `projects_information` (
  `Id` int(11) NOT NULL,
  `ProjectName` varchar(250) DEFAULT NULL,
  `Location` text DEFAULT NULL,
  `OwnerName` varchar(250) DEFAULT NULL,
  `Penalties` varchar(50) DEFAULT NULL,
  `StartDate` date DEFAULT NULL,
  `FinishDate` date DEFAULT NULL,
  `Details` text DEFAULT NULL,
  `Value` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `project_item_data`
--

CREATE TABLE `project_item_data` (
  `Id` int(11) NOT NULL,
  `WorkItem` varchar(50) DEFAULT NULL,
  `PlanningQuantity` double DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `StartDate` date DEFAULT NULL,
  `FinishDate` date DEFAULT NULL,
  `Details` text DEFAULT NULL,
  `ProjectIdFk` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `work_progress_fallow`
--

CREATE TABLE `work_progress_fallow` (
  `Id` int(11) NOT NULL,
  `WorkItem` varchar(50) DEFAULT NULL,
  `ActualQuantity` int(10) DEFAULT NULL,
  `CurrentDate` date DEFAULT NULL,
  `ProjectIdFk` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `contract`
--
ALTER TABLE `contract`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectIdFk` (`ProjectIdFk`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`EmpId`);

--
-- Indexes for table `labor_date`
--
ALTER TABLE `labor_date`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectIdFk` (`ProjectIdFk`);

--
-- Indexes for table `labor_fallow`
--
ALTER TABLE `labor_fallow`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectIdFk` (`ProjectIdFk`);

--
-- Indexes for table `machine_data`
--
ALTER TABLE `machine_data`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectIdFk` (`ProjectIdFk`);

--
-- Indexes for table `machine_fallow`
--
ALTER TABLE `machine_fallow`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectIdFk` (`ProjectIdFk`);

--
-- Indexes for table `material_data`
--
ALTER TABLE `material_data`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectIdFk` (`ProjectIdFk`);

--
-- Indexes for table `material_fallow`
--
ALTER TABLE `material_fallow`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectIdFk` (`ProjectIdFk`);

--
-- Indexes for table `projects_information`
--
ALTER TABLE `projects_information`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `project_item_data`
--
ALTER TABLE `project_item_data`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectIdFk` (`ProjectIdFk`);

--
-- Indexes for table `work_progress_fallow`
--
ALTER TABLE `work_progress_fallow`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ProjectIdFk` (`ProjectIdFk`);

--
-- AUTO_INCREMENT for dumped tables
--
ALTER TABLE `projects_information`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `contract`
--
ALTER TABLE `contract`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `EmpId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `labor_date`
--
ALTER TABLE `labor_date`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `labor_fallow`
--
ALTER TABLE `labor_fallow`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `machine_data`
--
ALTER TABLE `machine_data`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `machine_fallow`
--
ALTER TABLE `machine_fallow`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `material_data`
--
ALTER TABLE `material_data`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `material_fallow`
--
ALTER TABLE `material_fallow`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `project_item_data`
--
ALTER TABLE `project_item_data`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `work_progress_fallow`
--
ALTER TABLE `work_progress_fallow`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `contract`
--
ALTER TABLE `contract`
  ADD CONSTRAINT `contract_ibfk_1` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`),
  ADD CONSTRAINT `contract_ibfk_2` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`);

--
-- Constraints for table `labor_date`
--
ALTER TABLE `labor_date`
  ADD CONSTRAINT `labor_date_ibfk_1` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`),
  ADD CONSTRAINT `labor_date_ibfk_2` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`);

--
-- Constraints for table `labor_fallow`
--
ALTER TABLE `labor_fallow`
  ADD CONSTRAINT `labor_fallow_ibfk_1` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`),
  ADD CONSTRAINT `labor_fallow_ibfk_2` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`);

--
-- Constraints for table `machine_data`
--
ALTER TABLE `machine_data`
  ADD CONSTRAINT `machine_data_ibfk_1` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`),
  ADD CONSTRAINT `machine_data_ibfk_2` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`);

--
-- Constraints for table `machine_fallow`
--
ALTER TABLE `machine_fallow`
  ADD CONSTRAINT `machine_fallow_ibfk_1` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`),
  ADD CONSTRAINT `machine_fallow_ibfk_2` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`);

--
-- Constraints for table `material_data`
--
ALTER TABLE `material_data`
  ADD CONSTRAINT `material_data_ibfk_1` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`),
  ADD CONSTRAINT `material_data_ibfk_2` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`);

--
-- Constraints for table `material_fallow`
--
ALTER TABLE `material_fallow`
  ADD CONSTRAINT `material_fallow_ibfk_1` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`),
  ADD CONSTRAINT `material_fallow_ibfk_2` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`);

--
-- Constraints for table `project_item_data`
--
ALTER TABLE `project_item_data`
  ADD CONSTRAINT `project_item_data_ibfk_1` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`),
  ADD CONSTRAINT `project_item_data_ibfk_2` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`);

--
-- Constraints for table `work_progress_fallow`
--
ALTER TABLE `work_progress_fallow`
  ADD CONSTRAINT `work_progress_fallow_ibfk_1` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`),
  ADD CONSTRAINT `work_progress_fallow_ibfk_2` FOREIGN KEY (`ProjectIdFk`) REFERENCES `projects_information` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
