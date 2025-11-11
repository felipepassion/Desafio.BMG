
dotnet ef migrations add 2025_11_11_5_56_14 -c ApplicationDbContext -p ..\..\..\Users.Identity
dotnet ef migrations add 2025_11_11_5_56_14 -c PropostaAggcontext -p ..\..\..\Proposta\Proposta.Infra.Data
dotnet ef migrations add 2025_11_11_5_56_14 -c ContratacaoAggcontext -p ..\..\..\Contratacao\Contratacao.Infra.Data
dotnet ef migrations add 2025_11_11_5_56_14 -c UsersAggcontext -p ..\..\..\Users\Users.Infra.Data
