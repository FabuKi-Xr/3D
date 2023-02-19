select Fname , Lname
from EMPLOYEE AS E
where   exists (
                SELECT *
                from DEPENDENT
                where Ssn = Essn
            )
            AND
        exists (
                SELECT *
                from Department
                where Ssn = mgr_Ssn
        )