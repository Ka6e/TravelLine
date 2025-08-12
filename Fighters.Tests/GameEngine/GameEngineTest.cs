using Fighters.Logger;
using Moq;

namespace Fighters.Tests.GameEngine;

[TestFixture]
public class GameEngineTest
{
    private readonly Mock<IFightersLogger> _loggerMock;
    private readonly Fighters.GameEngine.GameEngine _gameEngine;

    public GameEngineTest()
    {
        _loggerMock = new Mock<IFightersLogger>();
        _gameEngine = new Fighters.GameEngine.GameEngine( _loggerMock.Object );
    }

    [Test]
    public void RunBattle_NotEnoughFighters_LogsError()
    {

    }
    
}
