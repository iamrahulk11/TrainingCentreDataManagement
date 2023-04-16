using Microsoft.AspNetCore.Mvc;

namespace TrainingCentreDataManagement.Models.Repository
{
    public class FacultyRepository: IFaculty
    {
            public ApplicationDb context;

            public FacultyRepository(ApplicationDb context)
            {
                this.context = context;
            }

            public IEnumerable<Faculty> getdata(int bname)
            {
           
                List<Faculty> li = new List<Faculty>();
            var batchN = context.batches.Where(e=>e.BatchId == bname);
            var bName = batchN.First().Batchname;
            if(bName == null)
            {

            }
            var x = from a in context.Faculties.Where(e => e.Batchname == bName) select a;
            var xl = x.ToList();
            
                foreach (var item in xl)
                {
                    //li.Add(item);
                    li.Add(new Faculty
                    {
                        FacultyId = item.FacultyId,
                        FacultyName = item.FacultyName,
                        Email = item.Email,
                        Batchname = item.Batchname
                    });
                }
            
                
                
                return li;
            }

            //insert
            public void AddNewRecord(Faculty sViewModel,int id)
            {
            
            var bname = context.batches.Where(e=>e.BatchId==id).SingleOrDefault();
            
            Faculty std = new Faculty()
            {
                
                FacultyName=sViewModel.FacultyName,
                Email=sViewModel.Email
               
            };
            std.Batchname = bname.Batchname;
            context.Add(std);
            context.SaveChanges();
            }
            //update
            public void EditARecord(Faculty sViewModel)
            {
                var s = context.Faculties.SingleOrDefault(e => e.Email == sViewModel.Email);

                if (s != null)
                {
                s.FacultyName = sViewModel.FacultyName;
                s.Email = sViewModel.Email;
                s.Batchname = sViewModel.Batchname;


                    context.SaveChanges();

                }
            }

            //delete
            public void DeleteRecord(Faculty sViewModel)
            {
                var faculty = context.Faculties.SingleOrDefault(e => e.FacultyId == sViewModel.FacultyId);
            context.Faculties.Remove(faculty);
                context.SaveChanges();
            }
        //search
        public Faculty search(int id)
        {
            Faculty s = new Faculty();
            Faculty se = context.Faculties.Where(x => x.FacultyId == id).SingleOrDefault();
            s.FacultyId = se.FacultyId;
            s.FacultyName = se.FacultyName;
            s.Email = se.Email;
            s.Batchname = se.Batchname;

            return s;
        }


    }
    }
