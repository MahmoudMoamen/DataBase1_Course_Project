use PostGrad_System

exec StudentRegister 'Mahmoud','Moamen','1234','MET',0,'mahmoud@email.com','hghghhhh';

exec SupervisorRegister 'Basel','Saad','1222','Met','basel@email'

Select dbo.userLogin (24,'1234') as Success;

exec addMobile 6,'01222'

exec AdminListSup

exec AdminViewSupervisorProfile 17

exec AdminViewAllTheses

Select dbo.AdminViewOnGoingTheses() as ThesisCount

exec AdminViewStudentThesisBySupervisor

exec AdminListNonGucianCourse 3869

exec AdminUpdateExtension 4401

Select dbo.AdminIssueThesisPayment(9211,88359,15,54.0) as Success

exec AdminViewStudentProfile 11

exec AdminIssueInstallPayment 4203,'2016-01-12'

exec AdminListAcceptPublication

exec AddCourse '454',4,400

exec linkCourseStudent  1683,11

exec addStudentCourseGrade 1683,11,70

exec ViewExamSupDefense '2014-03-08'

exec EvaluateProgressReport 16,7111,1577,1

exec ViewSupStudentsYears 15

exec SupViewProfile 16

exec ViewAStudentPublications 10

exec AddDefenseGucian 3903 ,'2001-1-1','as'

exec AddDefenseNonGucian 7416,'2018-03-04','a'

exec AddExaminer 1330,'2024-05-17','basel',1,'SM'

exec CancelThesis 8007

exec AddGrade 1330, 88

exec AddDefenseGrade 1330,'2024-05-17',80

exec AddCommentsGrade 9748,'2021-08-31','Weak defence, contains alot of undetailled points'

exec viewMyProfile 9

exec editMyProfile 9,'Basel', 'Saad', 'Scsdcmdsifs','basel.saad@gmail.com','tahrir st','Master'

exec addUndergradID 5,'343'

exec ViewCourseGrades 9

exec ViewCousrePaymentsInstall 9

exec ViewThesisPaymentsInstall 10

exec ViewUpcomingInstallments 6

exec ViewMissedInstallments 10

exec AddProgressReport 7111,'2001-1-1'

exec FillProgressReport 1330,9366,99,'qwxascascdf'

exec ViewEvalProgressReport 1330,9366

exec addPublication 'G','2011-03-04','AUC','Hall 1',0

exec linkPubThesis 8,7111
