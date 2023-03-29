using DesktopClient.Mapper;
using DesktopClient.Service.Interfaces;
using Grpc.Core;
using JobManager;
using Serilog;

namespace DesktopClient.Service
{
    public class RunScriptGrpcService : ScriptService.ScriptServiceBase
    {
        private readonly IScriptManagerService _scriptManagerService;

        public RunScriptGrpcService(IScriptManagerService scriptManagerService)
        {
            _scriptManagerService = scriptManagerService;
        }

        public override async Task<ScriptResponse> RunScript(ScriptRequest request, ServerCallContext context)
        {
            Log.Information("Running script from GRPC");
            var script = ScriptMapper.MapGrpcRequestToScript(request);
            await _scriptManagerService.RunScriptAsync(script);
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
            await _scriptManagerService.StopScriptAsync(script);
            return new ScriptResponse
            {
                IsSuccessful = true,
                AdditionalInformation = "ok"
            };
        }
    }
}