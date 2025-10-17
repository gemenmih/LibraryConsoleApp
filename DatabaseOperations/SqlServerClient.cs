
namespace DatabaseOperations;

public class SqlServerClient : IDatabaseClient
{
    /* MIKE'S TO DO: Read why should we use a CommandTimeout */
    private readonly string _connectionString = "";
    public int CommandTimeout { get; set; } = 30;
    public SqlServerClient(string connectionString)
    {
        _connectionString = connectionString;
    }
    /* MIKE'S TODO: Read about async vs sync  */
    public async Task DummyMethod()
    {
        throw new NotImplementedException();
    }

    public void UpdatedDummyMethod()
    {
        throw new NotImplementedException();
    }
    /* MIKE'S TODO: Implement the CRUD methods extended from the interface  
    CRUD = (Create-Read-Update-Delete) 
    Take into consideration 
    1- SqlConnection
    2- SqlCommand 
    3- With the SqlCommand you can also Insert and Updating while passing Parameters */
}