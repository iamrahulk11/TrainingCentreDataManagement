using System.Xml.Linq;

namespace TrainingCentreDataManagement.Models
{
    public class StudentRepository:Istudent
    {
        public ApplicationDb context;

        public StudentRepository(ApplicationDb context)
        {
            this.context = context;
        }

        public IEnumerable<Student> getdata(int bname)
        {
            List<Student> li = new List<Student>();
            var batchN = context.batches.Where(e => e.BatchId == bname);
            var bName = batchN.First().Batchname;
            if (bName == null)
            {

            }
            var x = from a in context.students.Where(e => e.Batchname == bName) select a;
            var xl = x.ToList();

            foreach (var item in xl)
            {
                //li.Add(item);
                li.Add(new Student
                {
                    Studentid = item.Studentid,
                    StudentName = item.StudentName,
                    Email = item.Email,
                    PhoneNo= item.PhoneNo,
                    SC= item.SC,
                    Batchname = item.Batchname
                });
            }



            return li;
        }

        //insert
        public void AddNewRecord(Student sViewModel,int id)
        {
            var bname = context.batches.Where(e => e.BatchId == id).SingleOrDefault();
            Student s = new Student()
            {

                StudentName = sViewModel.StudentName,
                Email = sViewModel.Email,
                PhoneNo=sViewModel.PhoneNo,
                SC=sViewModel.SC

            };
            s.Batchname = bname.Batchname;
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
                s.SC = sViewModel.SC;
                    s.Batchname=sViewModel.Batchname;
                context.SaveChanges();

            }
        }

        //delete
        public void DeleteRecord(Student sViewModel)
        {
            var s = context.students.SingleOrDefault(x => x.Email == sViewModel.Email);
            context.students.Remove(s);
            context.SaveChanges();
        }
        //search
        public Student search(int id)
        {
            Student s = new Student();
            Student se = context.students.Where(x => x.Studentid == id).SingleOrDefault();
            s.Studentid = se.Studentid;
            s.StudentName = se.StudentName;
            s.PhoneNo = se.PhoneNo;
            s.SC = se.SC;
            s.Email = se.Email;
            s.Batchname = se.Batchname;

            return s;
        }


    }
}
