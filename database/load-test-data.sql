USE [CS6232-G1];

INSERT INTO role([roleName]) VALUES('1:Self');
INSERT INTO role([roleName]) VALUES('2:Supervisor');
INSERT INTO role([roleName]) VALUES('3:Co-Worker');

-- cohort 1 is employees 1-10
-- cohort 2 is employees 11-20
-- cohort 3 is employees 21-30
-- employees 31-40 are not assigned a cohort
INSERT INTO cohort([cohortName]) VALUES('cohort-1');
INSERT INTO cohort([cohortName]) VALUES('cohort-2');
INSERT INTO cohort([cohortName]) VALUES('cohort-3');

INSERT INTO stage([stageName]) VALUES('stage-1');
INSERT INTO stage([stageName]) VALUES('stage-2');
INSERT INTO stage([stageName]) VALUES('stage-3');

INSERT INTO type([typeName],[answerRange]) VALUES('Type-1',5);
INSERT INTO type([typeName],[answerRange]) VALUES('Type-2',10);

-- Type 1 Categories
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(1,1,'T1 Category 1','Category #1 for Type 1 Eval');
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(1,2,'T1 Category 2','Category #2 for Type 1 Eval');
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(1,3,'T1 Category 3','Category #3 for Type 1 Eval');
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(1,4,'T1 Category 4','Category #4 for Type 1 Eval');
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(1,5,'T1 Category 5','Category #5 for Type 1 Eval');

-- Type 2 Categories
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(2,1,'T2 Category 1','Category #1 for Type 2 Eval');
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(2,2,'T2 Category 2','Category #2 for Type 2 Eval');
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(2,3,'T2 Category 3','Category #3 for Type 2 Eval');
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(2,4,'T2 Category 4','Category #4 for Type 2 Eval');
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(2,5,'T2 Category 5','Category #5 for Type 2 Eval');
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(2,6,'T2 Category 6','Category #6 for Type 2 Eval');
INSERT INTO category([typeId],[categoryNo],[categoryName],[Description]) VALUES(2,7,'T2 Category 7','Category #7 for Type 2 Eval');



-- Type 1 questions
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,1,1,'What is your answer to T1C1Q1?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,2,1,'What is your answer to T1C1Q2?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,3,1,'What is your answer to T1C1Q3?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,4,2,'What is your answer to T1C2Q4?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,5,2,'What is your answer to T1C2Q5?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,6,2,'What is your answer to T1C2Q6?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,7,3,'What is your answer to T1C3Q7?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,8,3,'What is your answer to T1C3Q8?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,9,3,'What is your answer to T1C3Q9?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,10,4,'What is your answer to T1C4Q10?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,11,4,'What is your answer to T1C4Q11?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,12,4,'What is your answer to T1C4Q12?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,13,5,'What is your answer to T1C5Q13?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,14,5,'What is your answer to T1C5Q14?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(1,15,5,'What is your answer to T1C5Q15?');

-- Type 2 questions
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,1,6,'What is your answer to T2C1Q1?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,2,6,'What is your answer to T2C1Q2?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,3,6,'What is your answer to T2C1Q3?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,4,6,'What is your answer to T2C1Q4?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,5,7,'What is your answer to T2C2Q5?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,6,7,'What is your answer to T2C2Q6?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,7,7,'What is your answer to T2C2Q7?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,8,7,'What is your answer to T2C2Q8?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,9,8,'What is your answer to T2C3Q9?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,10,8,'What is your answer to T2C3Q10?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,11,8,'What is your answer to T2C3Q11?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,12,8,'What is your answer to T2C3Q12?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,13,9,'What is your answer to T2C4Q13?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,14,9,'What is your answer to T2C4Q14?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,15,9,'What is your answer to T2C4Q15?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,16,9,'What is your answer to T2C4Q16?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,17,10,'What is your answer to T2C5Q17?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,18,10,'What is your answer to T2C5Q18?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,19,10,'What is your answer to T2C5Q19?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,20,10,'What is your answer to T2C5Q20?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,21,11,'What is your answer to T2C6Q21?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,22,11,'What is your answer to T2C6Q22?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,23,11,'What is your answer to T2C6Q23?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,24,11,'What is your answer to T2C6Q24?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,25,12,'What is your answer to T2C7Q25?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,26,12,'What is your answer to T2C7Q26?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,27,12,'What is your answer to T2C7Q27?');
INSERT INTO question([typeId],[questionNo],[categoryId],[question]) VALUES(2,28,12,'What is your answer to T2C7Q28?');


-- employees 1-40 are regular.  41 & 42 are admins.
-- for the test data, regular employees last names are EMP-#.
-- email is emp#@westga.edu, login and password are both emp#
-- for admins the login and password are either both admin1 or admin2
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Dawn','EMP-1','2383 Sit Road','Holywell','NY','E0Z 9B3','533-544-4004','emp1@westga.edu','emp1',0,1,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Alexander','EMP-2','Ap #753-7773 Ut, Av.','Norfolk','PA','5424SL','758-270-8261','emp2@westga.edu','emp2',0,1,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Guinevere','EMP-3','Ap #291-9381 Integer Avenue','Bonnyville','NJ','5054','772-538-7386','emp3@westga.edu','emp3',0,1,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Jenna','EMP-4','810 Pede St.','Florida','PA','616578','501-481-4796','emp4@westga.edu','emp4',0,1,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Debra','EMP-5','528-499 Tincidunt Av.','Onze-Lieve-Vrouw-Lombeek','PA','135248','624-955-4061','emp5@westga.edu','emp5',0,1,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Yolanda','EMP-6','9614 Augue. St.','Beaumont','PA','878181','932-453-4363','emp6@westga.edu','emp6',0,1,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Clementine','EMP-7','Ap #340-8741 Pharetra Rd.','Cognelee','PA','2821','404-697-8149','emp7@westga.edu','emp7',0,1,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Chancellor','EMP-8','4619 Vel Avenue','Hualane','NY','189376','429-326-8985','emp8@westga.edu','emp8',0,1,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Richard','EMP-9','7208 Auctor Street','Zeveneken','NY','880517','461-251-9027','emp9@westga.edu','emp9',0,1,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Lucius','EMP-10','P.O. Box 703, 1609 Mus. Rd.','Valleyview','NY','66615','945-305-0638','emp10@westga.edu','emp10',0,1,null);

INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Xyla','EMP-11','P.O. Box 627, 6888 Rutrum St.','Hampstead','NJ','V7W 6P0','846-313-4707','emp11@westga.edu','emp11',0,2,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Olga','EMP-12','P.O. Box 864, 1647 Sollicitudin Rd.','Coalhurst','PA','6045','545-712-5011','emp12@westga.edu','emp12',0,2,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Denton','EMP-13','609-5789 Orci St.','Saint-Denis-Bovesse','PA','31066','115-885-4805','emp13@westga.edu','emp13',0,2,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Elvis','EMP-14','4813 Quam, Ave','San Clemente','NJ','93695','551-152-2687','emp14@westga.edu','emp14',0,2,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Dean','EMP-15','P.O. Box 611, 1339 Blandit St.','Bergen Mons','NJ','9511','322-249-5713','emp15@westga.edu','emp15',0,2,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Caesar','EMP-16','283-3286 Sed, Avenue','Frankfort','VA','9498','462-182-6052','emp16@westga.edu','emp16',0,2,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Noelle','EMP-17','P.O. Box 653, 2238 Id Rd.','Juseret','VA','72332','687-133-9478','emp17@westga.edu','emp17',0,2,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Lawrence','EMP-18','713-2234 Dolor. Ave','Galmaarden','VA','04-602','240-556-5761','emp18@westga.edu','emp18',0,2,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Shelly','EMP-19','717-5966 Diam Rd.','Gentbrugge','PA','V5K 1Z1','849-495-6260','emp19@westga.edu','emp19',0,2,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Axel','EMP-20','9865 Donec Ave','Paillaco','NY','12872','502-330-2542','emp20@westga.edu','emp20',0,2,null);

INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Cyrus','EMP-21','378-7286 Est Street','Ripacandida','VA','2682','392-481-1634','emp21@westga.edu','emp21',0,3,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Jaime','EMP-22','Ap #677-6081 Mauris St.','St. Austell','PA','5240','236-155-2779','emp22@westga.edu','emp22',0,3,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Imelda','EMP-23','Ap #541-9599 Luctus St.','Swindon','NY','84317','910-203-5890','emp23@westga.edu','emp23',0,3,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Joelle','EMP-24','4588 Sem St.','Duluth','VA','91-933','884-346-3612','emp24@westga.edu','emp24',0,3,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Shay','EMP-25','P.O. Box 570, 6878 Quisque Rd.','Vosselaar','NJ','24-730','896-995-2113','emp25@westga.edu','emp25',0,3,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Brent','EMP-26','396-5153 Ipsum. Av.','Itabuna','PA','225424','463-157-7964','emp26@westga.edu','emp26',0,3,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Shana','EMP-27','929-8987 Phasellus St.','Cumberland County','PA','620649','608-712-3145','emp27@westga.edu','emp27',0,3,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Paula','EMP-28','9767 Nunc Ave','Giugliano in Campania','PA','1482','755-242-8119','emp28@westga.edu','emp28',0,3,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Trevor','EMP-29','Ap #913-8218 Pede. Rd.','Opglabbeek','NY','J5 4JB','695-791-2062','emp29@westga.edu','emp29',0,3,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Tamara','EMP-30','Ap #791-8237 Ultrices. St.','Bolinne','NJ','04995','348-988-3862','emp30@westga.edu','emp30',0,3,null);

INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Wallace','EMP-31','9341 Adipiscing Rd.','Vaughan','PA','00691','460-343-7696','emp31@westga.edu','emp31',0,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Jescie','EMP-32','Ap #187-7685 Sem St.','Lagos','PA','60801','516-241-7336','emp32@westga.edu','emp32',0,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Darius','EMP-33','551-951 Lectus St.','Sterrebeek','NY','M8P 4J2','225-438-4552','emp33@westga.edu','emp33',0,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Elaine','EMP-34','Ap #206-6843 Sed Rd.','Halkirk','NY','85393','342-780-9384','emp34@westga.edu','emp34',0,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('India','EMP-35','P.O. Box 540, 9723 Erat. Rd.','Guirsch','PA','G42 0JK','764-520-4424','emp35@westga.edu','emp35',0,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Jael','EMP-36','3703 Pharetra Av.','Pelotas','NJ','30896','434-711-5287','emp36@westga.edu','emp36',0,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Cherokee','EMP-37','785-7529 Sit Street','Belem','VA','8434','988-345-2425','emp37@westga.edu','emp37',0,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Quintessa','EMP-38','Ap #433-7609 Euismod Rd.','Eisleben','PA','199656','190-949-5044','emp38@westga.edu','emp38',0,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Galena','EMP-39','481-1409 At Avenue','Sete','VA','6943','521-421-4921','emp39@westga.edu','emp39',0,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Desirae','EMP-40','5180 Facilisis Rd.','Sherborne','NY','20229','775-613-5678','emp40@westga.edu','emp40',0,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Doris','ADMIN-1','Ap #325-3791 Ultrices, Road','Castiglione del Lago','PA','Y1S 5V1','203-953-1171','admin1@westga.edu','admin1',1,null,null);
INSERT INTO employee([firstName],[lastName],[streetAddress],[city],[state],[zipcode],[contactPhone],[emailAddress],[password],[isAdmin],[cohortID],[supervisorId]) VALUES('Phoebe','ADMIN-2','Ap #324-3230 Sit Street','Farrukhabad-cum-Fatehgarh','NY','39383','983-285-6186','admin2@westga.edu','admin2',1,null,null);
UPDATE employee SET supervisorId = 2 WHERE employeeId = 1;
UPDATE employee SET supervisorId = 3 WHERE employeeId = 2;
UPDATE employee SET supervisorId = 12 WHERE employeeId = 11;
UPDATE employee SET supervisorId = 13 WHERE employeeId = 12;

-- Evaluation Schedule for Cohort 1 Type 1 Evaluations
--    stage 1 and stage 2 complete.  stage 3 open
INSERT INTO evaluation_schedule([cohortId], [typeId],[stageId],[startDate],[endDate]) VALUES(1,1,1,'20140101','20141231');
INSERT INTO evaluation_schedule([cohortId], [typeId],[stageId],[startDate],[endDate]) VALUES(1,1,2,'20150101','20151231');
INSERT INTO evaluation_schedule([cohortId], [typeId],[stageId],[startDate],[endDate]) VALUES(1,1,3,'20160101','20161231');

-- Evaluation Schedule for Cohort 2 Type 2 Evaluations
--    stage 1 open
INSERT INTO evaluation_schedule([cohortId], [typeId],[stageId],[startDate],[endDate]) VALUES(1,2,3,'20160101','20161231');


----------- Evaluations ----------
-- Emp1 T1 stage 1 self/supervisor/coworker (completed)
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(1,1,1,1,1,'20140228');
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(1,1,1,2,2,'20140228');
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(1,1,1,3,3,'20140228');
-- Emp1 T1 stage 2 self/supervisor/coworker (completed)
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(1,1,2,1,1,'20150228');
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(1,1,2,2,2,'20150228');
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(1,1,2,3,3,'20150228');
-- Emp1 T1 stage 3 self/supervisor/coworker (not complete. co-worker selected)
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(1,1,3,1,1,null);
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(1,1,3,2,2,null);
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(1,1,3,3,3,null);

-- Emp2 T1 stage 1 self/supervisor/coworker (completed)
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(2,1,1,2,1,'20140228');
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(2,1,1,3,2,'20140228');
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(2,1,1,4,3,'20140228');
-- Emp2 T1 stage 2 self/supervisor/coworker (completed)
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(2,1,2,2,1,'20150228');
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(2,1,2,3,2,'20150228');
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(2,1,2,4,3,'20150228');
-- Emp2 T1 stage 3 self/supervisor/coworker (not complete. co-worker selected)
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(2,1,3,2,1,null);
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(2,1,3,3,2,null);
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(2,1,3,4,3,null);


-- Emp11 T2 stage 1 self/supervisor/coworker (not complete. co-worker selected)
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(11,2,1,11,1,null);
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(11,2,1,12,2,null);
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(11,2,1,13,3,null);

-- Emp12 T2 stage 1 self/supervisor/coworker (not complete. co-worker selected)
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(12,2,1,12,1,null);
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(12,2,1,13,2,null);
INSERT INTO evaluations([employeeId],[typeId],[stageId],[evaluator],[roleId],[completionDate]) VALUES(12,2,1,14,3,null);




-- answers for evaluation 1
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,1,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,2,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,3,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,4,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,5,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,6,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,7,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,8,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,9,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,10,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,11,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,12,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,13,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,14,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(1,15,4);

-- answers for evaluation 2
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,1,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,2,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,3,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,4,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,5,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,6,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,7,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,8,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,9,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,10,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,11,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,12,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,13,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,14,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(2,15,3);

-- answers for evaluation 3
 INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,1,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,2,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,3,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,4,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,5,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,6,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,7,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,8,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,9,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,10,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,11,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,12,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,13,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,14,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(3,15,3);


-- answers for evaluation 4
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,1,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,2,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,3,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,4,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,5,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,6,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,7,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,8,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,9,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,10,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,11,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,12,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,13,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,14,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(4,15,1);

-- answers for evaluation 5
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,1,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,2,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,3,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,4,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,5,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,6,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,7,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,8,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,9,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,10,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,11,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,12,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,13,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,14,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(5,15,5);


-- answers for evaluation 6
 INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,1,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,2,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,3,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,4,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,5,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,6,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,7,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,8,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,9,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,10,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,11,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,12,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,13,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,14,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(6,15,2);

-- answers for evaluation 10
 INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,1,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,2,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,3,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,4,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,5,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,6,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,7,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,8,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,9,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,10,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,11,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,12,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,13,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,14,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(10,15,4);


-- answers for evaluation 11
 INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,1,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,2,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,3,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,4,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,5,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,6,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,7,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,8,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,9,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,10,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,11,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,12,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,13,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,14,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(11,15,3);


-- answers for evaluation 12
 INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,1,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,2,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,3,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,4,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,5,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,6,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,7,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,8,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,9,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,10,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,11,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,12,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,13,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,14,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(12,15,1);

-- answers for evaluation  13
 INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,1,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,2,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,3,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,4,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,5,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,6,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,7,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,8,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,9,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,10,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,11,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,12,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,13,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,14,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(13,15,1);
-- answers for evaluation 14
 INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,1,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,2,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,3,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,4,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,5,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,6,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,7,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,8,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,9,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,10,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,11,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,12,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,13,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,14,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(14,15,2);

-- answers for evaluation 15
 INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,1,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,2,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,3,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,4,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,5,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,6,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,7,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,8,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,9,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,10,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,11,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,12,2);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,13,5);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,14,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(15,15,5);

-- answers for evaluation 16 (partially done)
 INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(16,16,9);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(16,17,7);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(16,18,1);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(16,19,4);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(16,20,10);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(16,21,3);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(16,22,9);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(16,23,8);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(16,24,10);
INSERT INTO answer([evaluationId],[questionId],[answer]) VALUES(16,25,8);







