namespace TrainingCentreDataManagement.Models.Repository
{
    public class BatchRepository:IBatch
    {
     
            public ApplicationDb context;

            public BatchRepository(ApplicationDb context)
            {
                this.context = context;
            }

            public IEnumerable<Batch> getdata()
            {
                List<Batch> li = new List<Batch>();
               
                var x = from a in context.batches select a;
                var xl = x.ToList();
                foreach (var item in xl)
                {
                    
                    li.Add(new Batch
                    {
                        BatchId = item.BatchId,
                        Batchname = item.Batchname
                        
                    });
                }
            
                return li;
            }

            //insert
            public void AddNewRecord(Batch sViewModel)
            {
            Batch batch = new Batch();

            batch.Batchname = sViewModel.Batchname;

            
            

            context.Add(batch);
                context.SaveChanges();
            }
            //update
            public void EditARecord(int id,Batch sViewModel)
            {
                var s = context.batches.SingleOrDefault(e => e.Batchname == sViewModel.Batchname);

                if (s != null)
                {
                     s.Batchname = sViewModel.Batchname;


                    context.SaveChanges();

                }
            }

            //delete
            public void DeleteRecord(Batch sViewModel)
            {
                var s = context.batches.Where(e=>e.Batchname == sViewModel.Batchname).SingleOrDefault();
                context.batches.Remove(s);
                context.SaveChanges();
            }
        //search
        public Batch search(int id)
        {
            Batch s = new Batch();
            Batch se = context.batches.Where(x => x.BatchId == id).SingleOrDefault();
            s.Batchname = se.Batchname;
           s.BatchId =se.BatchId;
            
            return s;
        }



    }
}