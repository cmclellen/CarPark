using ApprovalTests.Reporters;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace CarPark.UnitTests
{
    [TestFixture]
    public class UICoordinatorTests
    {
        [SetUp]
        protected void Setup()
        {
            StringBuilder = new StringBuilder();
        }

        private StringBuilder StringBuilder { get; set; }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void Run_ValidInputs_CorrectResult()
        {
            // ARRANGE
            StringBuilder sb = 
                new StringBuilder()
                // Early Bird
                .AppendLine("21/03/2017 06:00")
                .AppendLine("21/03/2017 16:00")

                // Early Bird
                .AppendLine("21/03/2017 06:00")
                .AppendLine("21/03/2017 16:00")

                // Weekend Rate
                .AppendLine("19/03/2017 16:00")
                .AppendLine("19/03/2017 23:00")

                // Standard Rate (t<1h)
                .AppendLine("21/03/2017 10:00")
                .AppendLine("21/03/2017 10:30")

                // Standard Rate (1h<=t<2h)
                .AppendLine("21/03/2017 10:00")
                .AppendLine("21/03/2017 11:00")

                // Standard Rate (2h<=t<3h)
                .AppendLine("21/03/2017 10:00")
                .AppendLine("21/03/2017 12:00")

                // Standard Rate (t>=3h)
                .AppendLine("21/03/2017 10:00")
                .AppendLine("21/03/2017 13:00")

                .AppendLine("exit");
            UICoordinator sut = new UICoordinator(new StringReader(sb.ToString()), new StringWriter(StringBuilder));

            // ACT
            sut.Run();

            // ASSERT
            ApprovalTests.Approvals.Verify(StringBuilder.ToString());
        }
    }
}