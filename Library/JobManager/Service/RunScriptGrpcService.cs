using Grpc.Core;
using JobManager.Mapper;
using Serilog;

namespace JobManager.Service
{
    public class RunScriptGrpcService : JobManager.ScriptService.ScriptServiceBase
    {
        private readonly IRunScriptService _runScriptService;

        public RunScriptGrpcService(IRunScriptService runScriptService)
        {
            _runScriptService = runScriptService;
        }

        public override async Task<ScriptResponse> RunScript(ScriptRequest request, ServerCallContext context)
        {
            Log.Information("Running script from GRPC");
            var script = ScriptMapper.MapGrpcRequestToScript(request);
            await _runScriptService.RunScriptAsync(script);
            return new ScriptResponse
            {
                IsSuccessful = true,
                AdditionalInformation = "ok"
            };
        }

        public override async Task<ScriptResponse> StopScript(ScriptRequest request, ServerCallContext context)
        {
            Log.Information("Stopping script from GRPC");
            var script = ScriptMapper.MapGrpcRequestToScript(request);
            await _runScriptService.StopScriptAsync(script);
            return new ScriptResponse
            {
                IsSuccessful = true,
                AdditionalInformation = "ok"
            };
        }
    }
}