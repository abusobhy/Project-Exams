

--(Moha@gmail.com,@aA12345) as admin And Student
--(zzzz@gmail.com,@aA12345) as Student
--INSERT Two Users

INSERT INTO AspNetUsers (
    Id, UserName, NormalizedUserName, Email, NormalizedEmail,
    EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp,
    PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled,
    LockoutEnd, LockoutEnabled, AccessFailedCount
) VALUES
-- User 1
('60f2f19e-646c-4cae-89bb-8ae466e9b7a6', 'Moha@gmail.com', 'MOHA@GMAIL.COM', 'Moha@gmail.com', 'MOHA@GMAIL.COM',
 0, 'AQAAAAIAAYagAAAAEJB3mP+1k7LrhRhGYud4Fd6xcTNmyTg9VUGjYoyAXKnGMBS/F1NjoZRC1+uKFMoErQ==', '5JGB4DINC7PDHEAOK72ADQXWXLARCTD4', 'f5b5ff17-f37d-4587-a38c-25b3a46f1084', '0123456789', 1, 0, NULL, 1, 0),

-- User 2
('1fe9b4a6-949c-444a-ad8c-0bbabcb98feb', 'zzzz@gmail.com', 'ZZZZ@GMAIL.COM', 'zzzz@gmail.com', 'ZZZZ@GMAIL.COM',
 0, 'AQAAAAIAAYagAAAAEJB3mP+1k7LrhRhGYud4Fd6xcTNmyTg9VUGjYoyAXKnGMBS/F1NjoZRC1+uKFMoErQ==', '3OLIBQAZJ654IXKDB57I7YLDSKUS7YHF', 'cb78b880-6b5b-4c6e-a515-7748ba643ee4', '0123456790', 1, 0, NULL, 1, 0)

 ----INSERT two Roles

 INSERT INTO AspNetRoles (
    Id, Name, NormalizedName, ConcurrencyStamp
) VALUES
-- Admin Role
('C246D6E5-7CB7-4EE4-B9EE-21A7447FAD03', 'Admin', 'Admin', Null),

-- Student Role
('7F2FB9DC-41B3-480C-B3F8-0C999C52ADF8', 'Student', 'Student', Null);


---- INSERT UserRoles

INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES

-- User 1 as Admin And User
('60f2f19e-646c-4cae-89bb-8ae466e9b7a6', 'C246D6E5-7CB7-4EE4-B9EE-21A7447FAD03'),

('60f2f19e-646c-4cae-89bb-8ae466e9b7a6', '7F2FB9DC-41B3-480C-B3F8-0C999C52ADF8'),

-- User 2 as Student
('1fe9b4a6-949c-444a-ad8c-0bbabcb98feb', '7F2FB9DC-41B3-480C-B3F8-0C999C52ADF8');



--Mathematics

INSERT INTO TbSubjectsTaught (Id, NameSubjects, Description, CreatedDate, CreatedBy, CurrentState)
VALUES
('15000000-0000-0000-0000-0000000000D1', N'Mathematics', N'Subject of numbers, algebra, and geometry', GETDATE(), NEWID(), 1);

---Exams Mathematics
INSERT INTO TbExams (Id, Title, Description, SubjectTaughId, CreatedDate, CreatedBy, CurrentState)
VALUES
('15100000-0000-0000-0000-0000000000D1', N' First Term ', N'First term math assessment', '15000000-0000-0000-0000-0000000000D1', GETDATE(), NEWID(), 1),
('15100000-0000-0000-0000-0000000000D2', N' Second Term ', N'Second term math assessment', '15000000-0000-0000-0000-0000000000D1', GETDATE(), NEWID(), 1);
----------------------------------------
--Physics
INSERT INTO TbSubjectsTaught (Id, NameSubjects, Description, CreatedDate, CreatedBy, CurrentState)
VALUES
('16000000-0000-0000-0000-0000000000E1', N'Physics', N'Subject of matter, energy, and motion', GETDATE(), NEWID(), 1);

---Exams Physics
INSERT INTO TbExams (Id, Title, Description, SubjectTaughId, CreatedDate, CreatedBy, CurrentState)
VALUES
('16100000-0000-0000-0000-0000000000E1', N' First Term ', N'First term physics assessment', '16000000-0000-0000-0000-0000000000E1', GETDATE(), NEWID(), 1),
('16100000-0000-0000-0000-0000000000E2', N' Second Term ', N'Second term physics assessment', '16000000-0000-0000-0000-0000000000E1', GETDATE(), NEWID(), 1);

----------------------------------------

--Computer Science
INSERT INTO TbSubjectsTaught (Id, NameSubjects, Description, CreatedDate, CreatedBy, CurrentState)
VALUES
('17000000-0000-0000-0000-0000000000E1', N'Computer Science', N'Exma programming and computer systems', GETDATE(), NEWID(), 1);

---Exams Computer Science

INSERT INTO TbExams (Id, Title, Description, SubjectTaughId, CreatedDate, CreatedBy, CurrentState)
VALUES
('17100000-0000-0000-0000-0000000000E1', N'  First Term ', N'Programming and basics', '17000000-0000-0000-0000-0000000000E1', GETDATE(), NEWID(), 1),
('17100000-0000-0000-0000-0000000000E2', N'  Second Term ', N'Data structures and systems', '17000000-0000-0000-0000-0000000000E1', GETDATE(), NEWID(), 1);



--Chemistry
INSERT INTO TbSubjectsTaught (Id, NameSubjects, Description, CreatedDate, CreatedBy, CurrentState)
VALUES
('18000000-0000-0000-0000-0000000000E1', N'Chemistry', N'The Exam of matter, atoms, and chemical reactions', GETDATE(), NEWID(), 1);

--Exams Chemistry

INSERT INTO TbExams (Id, Title, Description, SubjectTaughId, CreatedDate, CreatedBy, CurrentState)
VALUES
('18100000-0000-0000-0000-0000000000E1', N' First Term ', N'Atoms and Periodic Table', '18000000-0000-0000-0000-0000000000E1', GETDATE(), NEWID(), 1),
('18100000-0000-0000-0000-0000000000E2', N' Second Term ', N'Reactions and Compounds', '18000000-0000-0000-0000-0000000000E1', GETDATE(), NEWID(), 1);


---------AllQuestions

INSERT INTO TbQuestions (Id, ExamId, Title, Choice1, Choice2, Choice3, Choiec4, RightAnswer, QuestionOrder, CreatedDate, CreatedBy, CurrentState)
VALUES
('15110000-0000-0000-0000-0000000000D1', '15100000-0000-0000-0000-0000000000D1', N'What is 5 + 3?', N'6', N'7', N'8', N'9', N'8', 1, GETDATE(), NEWID(), 1),
('15110000-0000-0000-0000-0000000000D2', '15100000-0000-0000-0000-0000000000D1', N'What is the square root of 64?', N'6', N'8', N'7', N'9', N'8', 2, GETDATE(), NEWID(), 1),
('15110000-0000-0000-0000-0000000000D3', '15100000-0000-0000-0000-0000000000D1', N'What is 12 ÷ 4?', N'2', N'3', N'4', N'5', N'3', 3, GETDATE(), NEWID(), 1),
('15110000-0000-0000-0000-0000000000D4', '15100000-0000-0000-0000-0000000000D1', N'What is 7 x 6?', N'42', N'36', N'48', N'40', N'42', 4, GETDATE(), NEWID(), 1),
('15110000-0000-0000-0000-0000000000D5', '15100000-0000-0000-0000-0000000000D1', N'What is 10% of 200?', N'10', N'15', N'20', N'25', N'20', 5, GETDATE(), NEWID(), 1),
('15110000-0000-0000-0000-0000000000D6', '15100000-0000-0000-0000-0000000000D1', N'What is the result of 2^3?', N'6', N'8', N'9', N'7', N'8', 6, GETDATE(), NEWID(), 1),
('15110000-0000-0000-0000-0000000000D7', '15100000-0000-0000-0000-0000000000D1', N'How many sides does a triangle have?', N'3', N'4', N'5', N'6', N'3', 7, GETDATE(), NEWID(), 1),
('15110000-0000-0000-0000-0000000000D8', '15100000-0000-0000-0000-0000000000D1', N'What is the value of π (Pi) to 2 decimal places?', N'3.12', N'3.14', N'3.16', N'3.18', N'3.14', 8, GETDATE(), NEWID(), 1),
('15110000-0000-0000-0000-0000000000D9', '15100000-0000-0000-0000-0000000000D1', N'What is 15 x 2?', N'20', N'25', N'30', N'35', N'30', 9, GETDATE(), NEWID(), 1),
('15110000-0000-0000-0000-0000000000DA', '15100000-0000-0000-0000-0000000000D1', N'Which is a prime number?', N'4', N'6', N'7', N'8', N'7', 10, GETDATE(), NEWID(), 1);

INSERT INTO TbQuestions (Id, ExamId, Title, Choice1, Choice2, Choice3, Choiec4, RightAnswer, QuestionOrder, CreatedDate, CreatedBy, CurrentState)
VALUES
('15210000-0000-0000-0000-0000000000D1', '15100000-0000-0000-0000-0000000000D2', N'What is 9 x 9?', N'81', N'72', N'91', N'99', N'81', 1, GETDATE(), NEWID(), 1),
('15210000-0000-0000-0000-0000000000D2', '15100000-0000-0000-0000-0000000000D2', N'What is the value of 100 ÷ 25?', N'2', N'3', N'4', N'5', N'4', 2, GETDATE(), NEWID(), 1),
('15210000-0000-0000-0000-0000000000D3', '15100000-0000-0000-0000-0000000000D2', N'What is 3^2?', N'6', N'9', N'12', N'15', N'9', 3, GETDATE(), NEWID(), 1),
('15210000-0000-0000-0000-0000000000D4', '15100000-0000-0000-0000-0000000000D2', N'What is 14 + 5?', N'18', N'19', N'20', N'21', N'19', 4, GETDATE(), NEWID(), 1),
('15210000-0000-0000-0000-0000000000D5', '15100000-0000-0000-0000-0000000000D2', N'What is 45 ÷ 9?', N'4', N'5', N'6', N'7', N'5', 5, GETDATE(), NEWID(), 1),
('15210000-0000-0000-0000-0000000000D6', '15100000-0000-0000-0000-0000000000D2', N'What is 11 x 11?', N'111', N'121', N'131', N'141', N'121', 6, GETDATE(), NEWID(), 1),
('15210000-0000-0000-0000-0000000000D7', '15100000-0000-0000-0000-0000000000D2', N'How many degrees in a right angle?', N'45', N'90', N'180', N'360', N'90', 7, GETDATE(), NEWID(), 1),
('15210000-0000-0000-0000-0000000000D8', '15100000-0000-0000-0000-0000000000D2', N'What is 1000 - 1?', N'999', N'998', N'997', N'996', N'999', 8, GETDATE(), NEWID(), 1),
('15210000-0000-0000-0000-0000000000D9', '15100000-0000-0000-0000-0000000000D2', N'What comes next: 2, 4, 8, 16, ...?', N'18', N'20', N'24', N'32', N'32', 9, GETDATE(), NEWID(), 1),
('15210000-0000-0000-0000-0000000000DA', '15100000-0000-0000-0000-0000000000D2', N'What is the area of a rectangle (5 x 3)?', N'8', N'15', N'12', N'10', N'15', 10, GETDATE(), NEWID(), 1);

------>>>----

INSERT INTO TbQuestions (Id, ExamId, Title, Choice1, Choice2, Choice3, Choiec4, RightAnswer, QuestionOrder, CreatedDate, CreatedBy, CurrentState)
VALUES
('16110000-0000-0000-0000-0000000000E1', '16100000-0000-0000-0000-0000000000E1', N'What is the speed of light?', N'300,000 km/s', N'150,000 km/s', N'100,000 km/s', N'250,000 km/s', N'300,000 km/s', 1, GETDATE(), NEWID(), 1),
('16110000-0000-0000-0000-0000000000E2', '16100000-0000-0000-0000-0000000000E1', N'What is the unit of force?', N'Joule', N'Newton', N'Watt', N'Volt', N'Newton', 2, GETDATE(), NEWID(), 1),
('16110000-0000-0000-0000-0000000000E3', '16100000-0000-0000-0000-0000000000E1', N'What is gravity?', N'A push force', N'A magnetic force', N'A pulling force', N'None of the above', N'A pulling force', 3, GETDATE(), NEWID(), 1),
('16110000-0000-0000-0000-0000000000E4', '16100000-0000-0000-0000-0000000000E1', N'What is measured in Watts?', N'Force', N'Power', N'Energy', N'Mass', N'Power', 4, GETDATE(), NEWID(), 1),
('16110000-0000-0000-0000-0000000000E5', '16100000-0000-0000-0000-0000000000E1', N'Who discovered gravity?', N'Newton', N'Einstein', N'Galileo', N'Tesla', N'Newton', 5, GETDATE(), NEWID(), 1),
('16110000-0000-0000-0000-0000000000E6', '16100000-0000-0000-0000-0000000000E1', N'What is the formula of speed?', N's = t/d', N'v = d/t', N'v = t*d', N'v = s*t', N'v = d/t', 6, GETDATE(), NEWID(), 1),
('16110000-0000-0000-0000-0000000000E7', '16100000-0000-0000-0000-0000000000E1', N'What does a thermometer measure?', N'Pressure', N'Temperature', N'Energy', N'Length', N'Temperature', 7, GETDATE(), NEWID(), 1),
('16110000-0000-0000-0000-0000000000E8', '16100000-0000-0000-0000-0000000000E1', N'What type of energy is stored in a battery?', N'Thermal', N'Chemical', N'Kinetic', N'Nuclear', N'Chemical', 8, GETDATE(), NEWID(), 1),
('16110000-0000-0000-0000-0000000000E9', '16100000-0000-0000-0000-0000000000E1', N'Which planet has the most gravity?', N'Mars', N'Jupiter', N'Earth', N'Mercury', N'Jupiter', 9, GETDATE(), NEWID(), 1),
('16110000-0000-0000-0000-0000000000EA', '16100000-0000-0000-0000-0000000000E1', N'What is the SI unit of energy?', N'Joule', N'Watt', N'Volt', N'Calorie', N'Joule', 10, GETDATE(), NEWID(), 1);

INSERT INTO TbQuestions (Id, ExamId, Title, Choice1, Choice2, Choice3, Choiec4, RightAnswer, QuestionOrder, CreatedDate, CreatedBy, CurrentState)
VALUES
('16210000-0000-0000-0000-0000000000E1', '16100000-0000-0000-0000-0000000000E2', N'What is the main source of energy for Earth?', N'Wind', N'Coal', N'Sun', N'Oil', N'Sun', 1, GETDATE(), NEWID(), 1),
('16210000-0000-0000-0000-0000000000E2', '16100000-0000-0000-0000-0000000000E2', N'Which of the following is not a renewable energy?', N'Solar', N'Wind', N'Coal', N'Hydroelectric', N'Coal', 2, GETDATE(), NEWID(), 1),
('16210000-0000-0000-0000-0000000000E3', '16100000-0000-0000-0000-0000000000E2', N'Which device converts electrical energy into motion?', N'Motor', N'Generator', N'Battery', N'Capacitor', N'Motor', 3, GETDATE(), NEWID(), 1),
('16210000-0000-0000-0000-0000000000E4', '16100000-0000-0000-0000-0000000000E2', N'Which of these is a conductor?', N'Plastic', N'Wood', N'Copper', N'Glass', N'Copper', 4, GETDATE(), NEWID(), 1),
('16210000-0000-0000-0000-0000000000E5', '16100000-0000-0000-0000-0000000000E2', N'What is the function of a fuse?', N'Transmit electricity', N'Protect circuits', N'Store charge', N'Increase voltage', N'Protect circuits', 5, GETDATE(), NEWID(), 1),
('16210000-0000-0000-0000-0000000000E6', '16100000-0000-0000-0000-0000000000E2', N'What type of mirror is used in headlights?', N'Plane', N'Concave', N'Convex', N'Flat', N'Concave', 6, GETDATE(), NEWID(), 1),
('16210000-0000-0000-0000-0000000000E7', '16100000-0000-0000-0000-0000000000E2', N'What does a voltmeter measure?', N'Current', N'Resistance', N'Voltage', N'Power', N'Voltage', 7, GETDATE(), NEWID(), 1)

----->>>----


INSERT INTO TbQuestions (Id, ExamId, Title, Choice1, Choice2, Choice3, Choiec4, RightAnswer, QuestionOrder, CreatedDate, CreatedBy, CurrentState)
VALUES
('17110000-0000-0000-0000-0000000000E1', '17100000-0000-0000-0000-0000000000E1', N'What does CPU stand for?', N'Central Process Unit', N'Central Processing Unit', N'Computer Personal Unit', N'Central Programming Unit', N'Central Processing Unit', 1, GETDATE(), NEWID(), 1),
('17110000-0000-0000-0000-0000000000E2', '17100000-0000-0000-0000-0000000000E1', N'Which language is used for web development?', N'C++', N'Python', N'HTML', N'Java', N'HTML', 2, GETDATE(), NEWID(), 1),
('17110000-0000-0000-0000-0000000000E3', '17100000-0000-0000-0000-0000000000E1', N'What is the output of 2 + 3 in Python?', N'23', N'Error', N'5', N'None', N'5', 3, GETDATE(), NEWID(), 1),
('17110000-0000-0000-0000-0000000000E4', '17100000-0000-0000-0000-0000000000E1', N'Which one is a browser?', N'Windows', N'Chrome', N'Linux', N'Excel', N'Chrome', 4, GETDATE(), NEWID(), 1),
('17110000-0000-0000-0000-0000000000E5', '17100000-0000-0000-0000-0000000000E1', N'Which device stores data permanently?', N'RAM', N'ROM', N'Hard Drive', N'Cache', N'Hard Drive', 5, GETDATE(), NEWID(), 1),
('17110000-0000-0000-0000-0000000000E6', '17100000-0000-0000-0000-0000000000E1', N'Which symbol is used for comments in Python?', N'#', N'//', N'/*', N'--', N'#', 6, GETDATE(), NEWID(), 1),
('17110000-0000-0000-0000-0000000000E7', '17100000-0000-0000-0000-0000000000E1', N'Which command prints in Python?', N'print()', N'echo()', N'display()', N'write()', N'print()', 7, GETDATE(), NEWID(), 1),
('17110000-0000-0000-0000-0000000000E8', '17100000-0000-0000-0000-0000000000E1', N'Which of the following is an input device?', N'Monitor', N'Mouse', N'Speaker', N'Printer', N'Mouse', 8, GETDATE(), NEWID(), 1),
('17110000-0000-0000-0000-0000000000E9', '17100000-0000-0000-0000-0000000000E1', N'What does RAM stand for?', N'Read Access Memory', N'Random Access Memory', N'Read And Memory', N'Run Active Memory', N'Random Access Memory', 9, GETDATE(), NEWID(), 1),
('17110000-0000-0000-0000-0000000000EA', '17100000-0000-0000-0000-0000000000E1', N'Which of these is an operating system?', N'Google', N'Android', N'Intel', N'HP', N'Android', 10, GETDATE(), NEWID(), 1);


INSERT INTO TbQuestions (Id, ExamId, Title, Choice1, Choice2, Choice3, Choiec4, RightAnswer, QuestionOrder, CreatedDate, CreatedBy, CurrentState)
VALUES
('17210000-0000-0000-0000-0000000000E1', '17100000-0000-0000-0000-0000000000E2', N'What does SQL stand for?', N'Structured Query Language', N'Sequence Query Language', N'Simple Query Language', N'System Quality Logic', N'Structured Query Language', 1, GETDATE(), NEWID(), 1),
('17210000-0000-0000-0000-0000000000E2', '17100000-0000-0000-0000-0000000000E2', N'Which is a loop in programming?', N'if', N'while', N'def', N'class', N'while', 2, GETDATE(), NEWID(), 1),
('17210000-0000-0000-0000-0000000000E3', '17100000-0000-0000-0000-0000000000E2', N'Which is a valid data type?', N'Integer', N'Number', N'Digit', N'CharNum', N'Integer', 3, GETDATE(), NEWID(), 1),
('17210000-0000-0000-0000-0000000000E4', '17100000-0000-0000-0000-0000000000E2', N'Which one is not a programming language?', N'Python', N'C#', N'MySQL', N'Java', N'MySQL', 4, GETDATE(), NEWID(), 1),
('17210000-0000-0000-0000-0000000000E5', '17100000-0000-0000-0000-0000000000E2', N'Which of the following stores key-value pairs?', N'List', N'Set', N'Dictionary', N'Tuple', N'Dictionary', 5, GETDATE(), NEWID(), 1),
('17210000-0000-0000-0000-0000000000E6', '17100000-0000-0000-0000-0000000000E2', N'Which tag is used for paragraph in HTML?', N'<p>', N'<h1>', N'<div>', N'<span>', N'<p>', 6, GETDATE(), NEWID(), 1),
('17210000-0000-0000-0000-0000000000E7', '17100000-0000-0000-0000-0000000000E2', N'Which company developed Windows OS?', N'Apple', N'Microsoft', N'Google', N'IBM', N'Microsoft', 7, GETDATE(), NEWID(), 1),
('17210000-0000-0000-0000-0000000000E8', '17100000-0000-0000-0000-0000000000E2', N'What is a function in programming?', N'A value', N'A loop', N'A reusable block of code', N'A condition', N'A reusable block of code', 8, GETDATE(), NEWID(), 1),
('17210000-0000-0000-0000-0000000000E9', '17100000-0000-0000-0000-0000000000E2', N'Which software helps create presentations?', N'MS Word', N'MS Excel', N'MS PowerPoint', N'MS Paint', N'MS PowerPoint', 9, GETDATE(), NEWID(), 1),
('17210000-0000-0000-0000-0000000000EA', '17100000-0000-0000-0000-0000000000E2', N'Which is used for storing large data in databases?', N'Rows', N'Files', N'Tables', N'Cells', N'Tables', 10, GETDATE(), NEWID(), 1);

----->>>-----

INSERT INTO TbQuestions (Id, ExamId, Title, Choice1, Choice2, Choice3, Choiec4, RightAnswer, QuestionOrder, CreatedDate, CreatedBy, CurrentState)
VALUES
('18110000-0000-0000-0000-0000000000E1', '18100000-0000-0000-0000-0000000000E1', N'What is the chemical symbol for water?', N'O2', N'H2O', N'CO2', N'NaCl', N'H2O', 1, GETDATE(), NEWID(), 1),
('18110000-0000-0000-0000-0000000000E2', '18100000-0000-0000-0000-0000000000E1', N'What is the atomic number of Carbon?', N'12', N'6', N'8', N'14', N'6', 2, GETDATE(), NEWID(), 1),
('18110000-0000-0000-0000-0000000000E3', '18100000-0000-0000-0000-0000000000E1', N'Which subatomic particle has a negative charge?', N'Proton', N'Electron', N'Neutron', N'Ion', N'Electron', 3, GETDATE(), NEWID(), 1),
('18110000-0000-0000-0000-0000000000E4', '18100000-0000-0000-0000-0000000000E1', N'What is the center of an atom called?', N'Electron', N'Proton', N'Nucleus', N'Orbit', N'Nucleus', 4, GETDATE(), NEWID(), 1),
('18110000-0000-0000-0000-0000000000E5', '18100000-0000-0000-0000-0000000000E1', N'Which element has the symbol Na?', N'Nitrogen', N'Sodium', N'Neon', N'Silver', N'Sodium', 5, GETDATE(), NEWID(), 1),
('18110000-0000-0000-0000-0000000000E6', '18100000-0000-0000-0000-0000000000E1', N'What is the pH of a neutral solution?', N'0', N'14', N'7', N'1', N'7', 6, GETDATE(), NEWID(), 1),
('18110000-0000-0000-0000-0000000000E7', '18100000-0000-0000-0000-0000000000E1', N'What is the smallest unit of matter?', N'Atom', N'Molecule', N'Cell', N'Electron', N'Atom', 7, GETDATE(), NEWID(), 1),
('18110000-0000-0000-0000-0000000000E8', '18100000-0000-0000-0000-0000000000E1', N'Which state of matter has a definite shape and volume?', N'Liquid', N'Gas', N'Solid', N'Plasma', N'Solid', 8, GETDATE(), NEWID(), 1),
('18110000-0000-0000-0000-0000000000E9', '18100000-0000-0000-0000-0000000000E1', N'What is the boiling point of water in Celsius?', N'50°C', N'100°C', N'0°C', N'150°C', N'100°C', 9, GETDATE(), NEWID(), 1),
('18110000-0000-0000-0000-0000000000EA', '18100000-0000-0000-0000-0000000000E1', N'Which element is a noble gas?', N'Oxygen', N'Carbon', N'Neon', N'Hydrogen', N'Neon', 10, GETDATE(), NEWID(), 1);

INSERT INTO TbQuestions (Id, ExamId, Title, Choice1, Choice2, Choice3, Choiec4, RightAnswer, QuestionOrder, CreatedDate, CreatedBy, CurrentState)
VALUES
('18210000-0000-0000-0000-0000000000E1', '18100000-0000-0000-0000-0000000000E2', N'What type of bond is formed by sharing electrons?', N'Ionic bond', N'Covalent bond', N'Metallic bond', N'Weak bond', N'Covalent bond', 1, GETDATE(), NEWID(), 1),
('18210000-0000-0000-0000-0000000000E2', '18100000-0000-0000-0000-0000000000E2', N'What is formed when acids react with bases?', N'Gas', N'Precipitate', N'Salt and Water', N'Alkali', N'Salt and Water', 2, GETDATE(), NEWID(), 1),
('18210000-0000-0000-0000-0000000000E3', '18100000-0000-0000-0000-0000000000E2', N'What is the chemical formula for table salt?', N'NaCl', N'KCl', N'CaCO3', N'HCl', N'NaCl', 3, GETDATE(), NEWID(), 1),
('18210000-0000-0000-0000-0000000000E4', '18100000-0000-0000-0000-0000000000E2', N'Which gas is produced in photosynthesis?', N'Oxygen', N'Carbon dioxide', N'Nitrogen', N'Hydrogen', N'Oxygen', 4, GETDATE(), NEWID(), 1),
('18210000-0000-0000-0000-0000000000E5', '18100000-0000-0000-0000-0000000000E2', N'Which element is needed to make hemoglobin?', N'Iron', N'Calcium', N'Sodium', N'Zinc', N'Iron', 5, GETDATE(), NEWID(), 1),
('18210000-0000-0000-0000-0000000000E6', '18100000-0000-0000-0000-0000000000E2', N'Which gas is used in fire extinguishers?', N'Oxygen', N'Carbon Dioxide', N'Hydrogen', N'Nitrogen', N'Carbon Dioxide', 6, GETDATE(), NEWID(), 1),
('18210000-0000-0000-0000-0000000000E7', '18100000-0000-0000-0000-0000000000E2', N'Which process separates solids from liquids?', N'Filtration', N'Evaporation', N'Distillation', N'Condensation', N'Filtration', 7, GETDATE(), NEWID(), 1),
('18210000-0000-0000-0000-0000000000E8', '18100000-0000-0000-0000-0000000000E2', N'What is the mass number?', N'Number of protons', N'Protons + Neutrons', N'Only electrons', N'Only neutrons', N'Protons + Neutrons', 8, GETDATE(), NEWID(), 1),
('18210000-0000-0000-0000-0000000000E9', '18100000-0000-0000-0000-0000000000E2', N'Which element is a halogen?', N'Fluorine', N'Oxygen', N'Helium', N'Sodium', N'Fluorine', 9, GETDATE(), NEWID(), 1),
('18210000-0000-0000-0000-0000000000EA', '18100000-0000-0000-0000-0000000000E2', N'What is the color of copper sulfate solution?', N'Green', N'Blue', N'Red', N'Yellow', N'Blue', 10, GETDATE(), NEWID(), 1);
