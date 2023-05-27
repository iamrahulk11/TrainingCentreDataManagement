namespace TrainingCentreDataManagement.Models.Repository
{
    public class LoginRepository: ILogin
    {
        public ApplicationDb context;

        public LoginRepository(ApplicationDb context)
        {
            this.context = context;
        }
        public bool credentialCheck(LoginModel u)
        {
            try
            {
                var credentials = context.users.Where(m => m.username == u.username && m.password == u.password).FirstOrDefault();
                if (credentials == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                var message = ex;
                //throw ex;
            }
            
            return false;
            
        }
    }
}
