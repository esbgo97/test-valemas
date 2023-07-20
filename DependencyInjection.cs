class Vehiculo {
    public int Id { get; set; }
    public string Marca { get; set; }
    public int Modelo { get; set; }
    public string   Descripcion { get; set; }
}

interface IVehiculoRepository {
    int CreateVehicle(Vehiculo vehiculo);
    List<Vehiculo> GetVehiculos();
}

class VehiculoRepository: IVehiculoRepository {

    private readonly IDbConnection _connection;
    public VehiculoRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public int CreateVehicle(Vehiculo vehiculo){
        var result = _Connection.ExecuteQuery();
        return 1;
    }

    public List<Vehiculo> GetVehiculos(){
        var result = _Connection.ExecuteQuery();
        return new List<Vehiculo>();
    }
}

//Startup.cs
//services.AddTransient<IVehiculoRepository, VehiculoRepository>();

class VehiculoService {
    private IVehiculoRepository _repository;
    public DependencyInjection(IVehiculoRepository repository)
    {
        _repository = repository;
    }
    /*
        Implement Service Methods
    */
}