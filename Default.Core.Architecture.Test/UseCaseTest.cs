using System.Reflection;
using System.Xml.Linq;


namespace Default.Core.Architecture.Test
{
    [TestClass]
    public class UseCaseTest
    {
        [TestMethod]
        public void TestProjectReferences()
        {
            string projectToTest = "Default.Core.UseCase"; 
            string[] expectedReferences =
            {
                "Default.Core.Domain"                
            };

            
            var projectPath = $@"C:\Projetos\default-core\{projectToTest}\{projectToTest}.csproj"; 
            
            var projectDocument = XDocument.Load(projectPath);

            
            var projectReferences = projectDocument.Descendants("ProjectReference")
                .Select(pr => Path.GetFileNameWithoutExtension(pr.Attribute("Include").Value))
                .ToList();

            
            foreach (var expectedReference in expectedReferences)
            {
                Assert.IsTrue(projectReferences.Contains(expectedReference),
                    $"O projeto {projectToTest} deve ter uma referência ao projeto {expectedReference}");
            }
        }

        [TestMethod]
        public void TestNamingConventions()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var serviceTypes = assembly.GetTypes()
                .Where(t => t.IsClass && t.Namespace == "\"Default.Core.UseCase"); 

            foreach (var serviceType in serviceTypes)
            {
                Assert.IsTrue(serviceType.Name.EndsWith("UseCase"),
                    $"A classe {serviceType.Name} deve terminar com 'UseCase'");
            }
        }
    }
}