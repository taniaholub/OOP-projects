using Lecture_23_10_2023.UI;
using Lecture_23_10_2023.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023
{
    public class GenTest<CustomType> where CustomType: IUserInterface
    {
        List<CustomType> list;
        public GenTest()
        {
            list = new List<CustomType>();
        }

        public void Add(CustomType value)
        {
            
            list.Add(value);
        }
    }

    class Test
    {
        public Test()
        {
            GenTest<IUserInterface> genText1 = new GenTest<IUserInterface>();
            GenTest<AddStudentUI> genText2 = new GenTest<AddStudentUI>();
        }
    }
}
