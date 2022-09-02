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
        /// ������Ҫ���صĹ����б����ڸ��б��еĹ��ӻᱻ�ص��� HookProivder ����
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
        /// ֪ͨ�û��� HookProvier �Ѿ��� emqx ��ж��
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
        /// ������֤
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
        /// �������ļ�Ȩ, ִ�� ����/���� ����ǰ
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
        /// ������յ��ͻ��˵����ӱ���ʱ, �������ӱ���
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
        /// �����׼���·�����Ӧ����ʱ, �·�����Ӧ��	
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
        /// �ͻ�����֤��ɲ��ɹ�����ϵͳ��
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
        /// �ͻ������Ӳ���׼���ر�ʱ
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
        /// �յ����ı��ĺ�ִ�� client.authorize ��Ȩǰ ,��������
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
        /// �յ�ȡ�����ı��ĺ�, ȡ������
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
        /// client.connected ִ����ɣ��Ҵ����µĻỰ��, �Ự����
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
        /// ��ɶ��Ĳ�����, �Ự��������
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
        /// ���ȡ�����Ĳ�����
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
        /// client.connected ִ����ɣ��ҳɹ��ָ��ɵĻỰ��Ϣ��
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
        /// �Ự���ڱ��Ƴ�����ֹ��
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
        /// �Ự���ڱ��ӹܶ���ֹ��
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
        ///  �Ự��������ԭ����ֹ��
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
        /// ��Ϣ������������ڷ�����·�ɣ���Ϣǰ
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
        /// ��Ϣ��ִ����������յ��ͻ��˷��ص���Ϣ ACK ��
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
        /// ��ϢͶ�ݣ���Ϣ׼��Ͷ�ݵ��ͻ���ǰ
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
        /// ��Ϣ����������������Ϣ��������
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
        /// �������еĹ��� 
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