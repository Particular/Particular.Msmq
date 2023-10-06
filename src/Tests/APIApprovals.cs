namespace Tests
{
    using NUnit.Framework;
    using Particular.Approvals;
    using Particular.Msmq;
    using PublicApiGenerator;

    [TestFixture]
    public class APIApprovals
    {
        [Test]
        public void ApproveApi()
        {
            var publicApi = typeof(MessageQueue).Assembly.GeneratePublicApi(new ApiGeneratorOptions
            {
                ExcludeAttributes = ["System.Runtime.Versioning.TargetFrameworkAttribute", "System.Reflection.AssemblyMetadataAttribute"]
            });

            Approver.Verify(publicApi);
        }
    }
}
