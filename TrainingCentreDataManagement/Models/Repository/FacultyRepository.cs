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
                        FacultyName = item.FacultyName,
                        Email = item.Email,
                        Batchname = item.Batchname
                    });
                }
            
                
                
                return li;
            }

            //insert
            public void AddNewRecord(Faculty sViewModel, Batch model)
            {
            
            var bname = from m in context.batches select m;
            
            var std = new Faculty()
            {
                FacultyName=sViewModel.FacultyName,
                Email=sViewModel.Email
               
            };
            std.Batchname = bname.First().Batchname;
            context.Add(std);
            context.SaveChanges();
            }
            //update
            public void EditARecord(Faculty sViewModel)
            {
                var s = context.Faculties.SingleOrDefault(e => e.Email == sViewModel.Email);

                if (s != null)
                {
                    // StudentId = model.StudentId;


                    context.SaveChanges();

                }
            }

            //delete
            public void DeleteRecord(Faculty sViewModel)
            {
                var s = context.Faculties.Where(x => x.Email == sViewModel.Email).SingleOrDefault();
                context.Faculties.Remove(s);
                context.SaveChanges();
            }
            //search
            


        }
    }
