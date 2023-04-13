namespace TrainingCentreDataManagement.Models
{
    public class StudentRepository:Istudent
    {
        public ApplicationDb context;

        public StudentRepository(ApplicationDb context)
        {
            this.context = context;
        }

        public IEnumerable<Student> getdata()
        {
            List<Student> li = new List<Student>();
            
            var x = from a in context.students select a;
            var xl = x.ToList();
            foreach (var item in xl)
            {
                //li.Add(item);
                li.Add(new Student
                {
                    Email = item.Email,
                    StudentName=item.StudentName,
                    PhoneNo=item.PhoneNo

                });
            }
            return li;
        }

        //insert
        public void AddNewRecord(Student sViewModel)
        {
            Student s = new Student();

           
            context.Add(s);
            context.SaveChanges();
        }
        //update
        public void EditARecord(Student sViewModel)
        {
            var s = context.students.SingleOrDefault(e => e.Email == sViewModel.Email);

            if (s != null)
            {
                // StudentId = model.StudentId;
               s.Email = sViewModel.Email;
                s.StudentName = sViewModel.StudentName;
                s.PhoneNo = sViewModel.PhoneNo;

                context.SaveChanges();

            }
        }

        //delete
        public void DeleteRecord(Student sViewModel)
        {
            var s = context.students.Where(x => x.Email == sViewModel.Email).SingleOrDefault();
            context.students.Remove(s);
            context.SaveChanges();
        }
        //search
        


    }
}
