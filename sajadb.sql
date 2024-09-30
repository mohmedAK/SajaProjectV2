CREATE TABLE `projects_information` (
  `id` int NOT NULL AUTO_INCREMENT,
  `project_name` varchar(250),
  `location` TEXT,
  `owner_name` varchar(250),
  `penalties` varchar(50),
  `start_date` date,
  `finsh_date` date,
  `details` TEXT,
  PRIMARY KEY (`id`)
);

CREATE TABLE `contract` (
  `id` int NOT NULL AUTO_INCREMENT,
  `contractor_name` varchar(250),
  `company_name` varchar(250),
  `start_date` date,
  `finsh_date` date,
  `details` TEXT,
  `project_id_fk` int,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`)
);

CREATE TABLE `labor_date` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(250),
  `labor_type` varchar(250),
  `occupation` varchar(250),
  `wage` real,
  `project_id_fk` int,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`)
);

CREATE TABLE `labor_fallow` (
  `id` int NOT NULL AUTO_INCREMENT,
  `work_item` varchar(50),
  `labor_type` varchar(50),
  `num_labor` int,
  `work_day` int,
  `curen_date` date,
  `project_id_fk` int,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`)
);

CREATE TABLE `machine_data` (
  `id` int NOT NULL AUTO_INCREMENT,
  `machine_name` varchar(50),
  `machine_number` varchar(50),
  `wage_rent` real,
  `wage_maintance` real,
  `project_id_fk` int,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`)
);

CREATE TABLE `machine_fallow` (
  `id` int NOT NULL AUTO_INCREMENT,
  `work_item` varchar(50),
  `machine_name` varchar(50),
  `ownership` varchar(50),
  `rent_days` int,
  `op_days` int,
  `curen_date` date,
  `project_id_fk` int,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`)
);

CREATE TABLE `material_data` (
  `id` int NOT NULL AUTO_INCREMENT,
  `work_item` varchar(50),
  `material_name` varchar(50),
  `planning_qun` int,
  `unit` varchar(50),
  `price` real,
  `details` TEXT,
  `project_id_fk` int,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`)
);

CREATE TABLE `material_fallow` (
  `id` int NOT NULL AUTO_INCREMENT,
  `work_item` varchar(50),
  `actual_qun` int,
  `curen_date` date,
  `project_id_fk` int,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`)
);

CREATE TABLE `project_item_data` (
  `id` int NOT NULL AUTO_INCREMENT,
  `work_item` varchar(50),
  `planning_Qun` real,
  `unit` varchar(50),
  `price` real,
  `start_date` date,
  `finsh_date` date,
  `details` TEXT,
  `project_id_fk` int,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`)
);

CREATE TABLE `work_progress_fallow` (
  `id` int NOT NULL AUTO_INCREMENT,
  `work_item` varchar(50),
  `actual_qun` int(10),
  `curen_date` date,
  `project_id_fk` int,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`)
);


ALTER TABLE `contract` ADD FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`);

ALTER TABLE `machine_fallow` ADD FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`);

ALTER TABLE `labor_date` ADD FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`);

ALTER TABLE `material_data` ADD FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`);

ALTER TABLE `work_progress_fallow` ADD FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`);

ALTER TABLE `labor_fallow` ADD FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`);

ALTER TABLE `material_fallow` ADD FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`);

ALTER TABLE `project_item_data` ADD FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`);

ALTER TABLE `machine_data` ADD FOREIGN KEY (`project_id_fk`) REFERENCES `projects_information` (`id`);
