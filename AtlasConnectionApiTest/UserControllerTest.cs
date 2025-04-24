using AtlasConnectionApiCode.Controllers;
using AtlasConnectionApiCode.Dto;
using AtlasConnectionApiCode.Dto.Request;
using AtlasConnectionApiCode.Service;
using Moq;
using System.Threading.Tasks;

namespace AtlasConnectionApiTest;

[TestFixture]
public class UserControllerTest
{
    private Mock<IUserService> _mockUserService;
    private UserController _userController;

    [SetUp]
    public void SetUp()
    {
        _mockUserService = new Mock<IUserService>();
        _userController = new UserController(_mockUserService.Object);
    }

    [Test]
    public async Task SaveUser()
    {
        SaveUserDtoRequest saveUserRequest = LoadSaveUserData;
        var expectedResult = new GenericResponse()
        {
            Message = "",
            Success = true,
        };

        _mockUserService.Setup(service => service.SaveUser(saveUserRequest)).ReturnsAsync(expectedResult);

        var result = await _userController.SetUser(saveUserRequest);

        Assert.IsTrue(result.Value.Success);
    }

    private SaveUserDtoRequest LoadSaveUserData => new()
    {   
        Id = null,
        Name = "Prueba",
        LastName = "Prueba Lastname",
        BirthDate = DateOnly.Parse(DateTime.Now.AddYears(-30).ToString()),
        Directions = [],
        PhoneNumbers = []
    };
}
