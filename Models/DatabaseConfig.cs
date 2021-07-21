namespace DotNetCoreWebAPI.Models {

     public record DatabaseConfig { 
          public string DBURL { get; init; }
          public string DBUserName { get; init; }
          public string DBPassword { get; init; }
     }

}