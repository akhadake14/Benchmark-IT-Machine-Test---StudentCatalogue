using StudentCatalogue.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCatalogue.DAL
{
    interface DatabaseActivity
    {
        int SaveStudentData(Student clsStudentData);

        List<Student> StudentList();


    }
}
