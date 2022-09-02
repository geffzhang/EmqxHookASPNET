using Emqx.Exhook.V2;
using Grpc.Core;

namespace EmqxHookASPNET.Services
{
    public class HookProviderGrpcService : HookProvider.HookProviderBase
    {
        private readonly ILogger<HookProviderGrpcService> _logger;
        private Verifier _verifier;

        public HookProviderGrpcService(ILogger<HookProviderGrpcService> logger, Verifier verifier)
        {
            this._logger = logger;
            this._verifier = verifier;
        }

        /// <summary>
        /// 返回需要挂载的钩子列表。仅在该列表中的钩子会被回调到 HookProivder 服务。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<LoadedResponse> OnProviderLoaded(ProviderLoadedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnProviderLoaded: {request}" );
            var response = new LoadedResponse();
            response.Hooks.AddRange(GetHookSpec());
            return Task.FromResult(response); 
        }

        /// <summary>
        /// 通知用户该 HookProvier 已经从 emqx 中卸载
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnProviderUnloaded(ProviderUnloadedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnProviderUnloaded: {request}");
            return Task.FromResult(new EmptySuccess());
        }

        /// <summary>
        /// 连接认证
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<ValuedResponse> OnClientAuthenticate(ClientAuthenticateRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnClientAuthenticate:{request}");
            bool passed = _verifier.Verify(request.Clientinfo);
            ValuedResponse reply = new ValuedResponse();
            reply.BoolResult = passed;
            reply.Type = ValuedResponse.Types.ResponsedType.StopAndReturn;

            return Task.FromResult(reply);
        }

        /// <summary>
        /// 发布订阅鉴权, 执行 发布/订阅 操作前
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<ValuedResponse> OnClientAuthorize(ClientAuthorizeRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnClientAuthorize:{request}");
             ValuedResponse reply = new ValuedResponse();
            reply.BoolResult = true;
            reply.Type = ValuedResponse.Types.ResponsedType.StopAndReturn;

            return Task.FromResult(reply);
        }

        /// <summary>
        /// 服务端收到客户端的连接报文时, 处理连接报文
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnClientConnect(ClientConnectRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnClientConnect:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 服务端准备下发连接应答报文时, 下发连接应答	
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnClientConnack(ClientConnackRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnClientConnack:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 客户端认证完成并成功接入系统后
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnClientConnected(ClientConnectedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnClientConnected:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 客户端连接层在准备关闭时
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnClientDisconnected(ClientDisconnectedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnClientDisconnected:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 收到订阅报文后，执行 client.authorize 鉴权前 ,订阅主题
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnClientSubscribe(ClientSubscribeRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnClientSubscribe:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 收到取消订阅报文后, 取消订阅
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnClientUnsubscribe(ClientUnsubscribeRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnClientUnsubscribe:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// client.connected 执行完成，且创建新的会话后, 会话创建
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnSessionCreated(SessionCreatedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnSessionCreated:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 完成订阅操作后, 会话订阅主题
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnSessionSubscribed(SessionSubscribedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnSessionSubscribed:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 完成取消订阅操作后
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnSessionUnsubscribed(SessionUnsubscribedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnSessionUnsubscribed:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// client.connected 执行完成，且成功恢复旧的会话信息后
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnSessionResumed(SessionResumedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnSessionResumed:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 会话由于被移除而终止后
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnSessionDiscarded(SessionDiscardedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnSessionDiscarded:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 会话由于被接管而终止后
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnSessionTakenover(SessionTakenoverRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnSessionTakenover:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        ///  会话由于其他原因被终止后
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnSessionTerminated(SessionTerminatedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnSessionTerminated:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 消息发布，服务端在发布（路由）消息前
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<ValuedResponse> OnMessagePublish(MessagePublishRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnMessagePublish:{request}");
            ValuedResponse reply = new ValuedResponse();
            reply.Message = request.Message;
            reply.Type = ValuedResponse.Types.ResponsedType.StopAndReturn;
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 消息回执，服务端在收到客户端发回的消息 ACK 后
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnMessageAcked(MessageAckedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnMessageAcked:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 消息投递，消息准备投递到客户端前
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnMessageDelivered(MessageDeliveredRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnMessageDelivered:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }

        /// <summary>
        /// 消息丢弃，发布出的消息被丢弃后
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptySuccess> OnMessageDropped(MessageDroppedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"OnMessageDropped:{request}");
            EmptySuccess reply = new EmptySuccess();
            return Task.FromResult(reply);
        }
     
        /// <summary>
        /// 挂载所有的钩子 
        /// </summary>
        /// <returns></returns>
        private static HookSpec[] GetHookSpec()
        {
            HookSpec[] specs = {
                new HookSpec() { Name = "client.connect" },
                new HookSpec() { Name = "client.connack" },
                new HookSpec() { Name = "client.connected" },
                new HookSpec() { Name = "client.disconnected" },
                //new HookSpec() { Name = "client.authenticate" },
                //new HookSpec() { Name = "client.authorize" },

                new HookSpec() { Name = "client.subscribe" },
                new HookSpec() { Name = "client.unsubscribe" },

                new HookSpec() { Name = "session.created" },
                new HookSpec() { Name = "session.subscribed" },
                new HookSpec() { Name = "session.unsubscribed" },
                new HookSpec() { Name = "session.resumed" },
                new HookSpec() { Name = "session.discarded" },
                new HookSpec() { Name = "session.terminated" },

                new HookSpec() { Name = "message.publish" },
                new HookSpec() { Name = "message.delivered" },
                new HookSpec() { Name = "message.acked" },
                new HookSpec() { Name = "message.dropped" }
            };

            return specs;
        }
    }
}