using System.Drawing;
using System.Security;
using System.Security.Principal;

namespace LudoTests;

public class UnitTest1
{
[Fact]
public void TestPlayerCount_4Players_SRPos()
{
    // Given

    // When

    // Then
}

[Fact]
public void TestPlayerCount_Over4Players_SRPos()
{
    
    // Given

    // When

    // Then       
}

[Fact]
public void TestPlayerCount_Sub4Players_SRPos()
{
    // Given

    // When

    // Then
}

[Fact]
public void TestPlayerCount_0Players_SRPos()
{
    // Given

    // When

    // Then
}

[Fact]
public void TestDiceRoll_SingleRoll_SRPos()
{
    // Given
    var dice = new Dice();
    var roll = dice.Roll();
    // When

    // Then
    Assert.InRange<int>(roll,1,6);    
}

[Fact]
public void TestPieceMove_EmptySingle_SRPos()
{
    // Given
    var grid = new GridSpace[2]{new GridSpace(),new GridSpace()};
    grid[0].Setup(grid[1]);
    var testPiece = new LudoPiece(Color.Blue);
    grid[0].pieces[0] = testPiece;
    grid[0].SendPieceForward(grid[0].pieces[0], 1);
    // Then
    Assert.Contains(testPiece, grid[1].pieces);
}

[Fact]
public void TestPieceMove_EmptyMulti_SRPos()
{
    // Given
    var grid = new GridSpace[4]{new GridSpace(),new GridSpace(),new GridSpace(),new GridSpace()};
    grid[0].Setup(grid[1]);
    grid[1].Setup(grid[2]);
    grid[2].Setup(grid[3]);
    var testPiece = new LudoPiece(Color.Blue);
    grid[0].pieces[0] = testPiece;
    grid[0].SendPieceForward(grid[0].pieces[0], 3);
    // Then
    Assert.Contains(testPiece, grid[3].pieces);
}

[Fact]
public void TestPieceMove_AlliedOcc_SRPos()
{
    var grid = new GridSpace[2]{new GridSpace(),new GridSpace()};
    grid[0].Setup(grid[1]);
    var testPieceA = new LudoPiece(Color.Blue);
    var testPieceB = new LudoPiece(Color.Blue);
    grid[0].pieces[0] = testPieceA;
    grid[1].pieces[0] = testPieceB;
    grid[0].SendPieceForward(grid[0].pieces[0], 1);
    // Then
    Assert.Contains(testPieceA, grid[1].pieces);
    Assert.Contains(testPieceB, grid[1].pieces);
}

[Fact]
public void TestPieceMove_EnemyOcc1_SRPos()
{
    var grid = new GridSpace[2]{new GridSpace(),new GridSpace()};
    grid[0].Setup(grid[1]);
    var testPieceA = new LudoPiece(Color.Blue);
    var testPieceB = new LudoPiece(Color.Red);
    grid[0].pieces[0] = testPieceA;
    grid[1].pieces[0] = testPieceB;
    grid[0].SendPieceForward(grid[0].pieces[0], 1);
    // Then
    Assert.Contains(testPieceA, grid[1].pieces);
    Assert.DoesNotContain(testPieceB, grid[1].pieces);
}

[Fact]
public void TestPieceMove_EnemyOcc2_SRPos()
{
    var grid = new GridSpace[2]{new GridSpace(),new GridSpace()};
    grid[0].Setup(grid[1]);
    var testPieceA = new LudoPiece(Color.Blue);
    var testPieceB = new LudoPiece(Color.Red);
    var testPieceC = new LudoPiece(Color.Red);
    grid[0].pieces[0] = testPieceA;
    grid[1].pieces[0] = testPieceB;
    grid[1].pieces[1] = testPieceC;
    grid[0].SendPieceForward(grid[0].pieces[0], 1);
    // Then
    Assert.Contains(testPieceB, grid[1].pieces);
    Assert.Contains(testPieceC, grid[1].pieces);
    Assert.DoesNotContain(testPieceA, grid[1].pieces);
}

[Fact]
public void TestPieceMove_IntoTrueZone_SRPos()
{
    var grid = new GridSpace[3]{new SortingSpace(),new GridSpace(), new GoalSpace(Color.Blue)};
    grid[0].Setup(grid[1], grid[2]);
    var testPiece = new LudoPiece(Color.Blue);
    grid[0].pieces[0] = testPiece;
    grid[0].SendPieceForward(grid[0].pieces[0], 1);
    // Then
    Assert.Contains(testPiece, grid[2].pieces);
    Assert.DoesNotContain(testPiece, grid[1].pieces);
}

[Fact]
public void TestPieceMove_IntoFalseZone_SRPos()
{
    var grid = new GridSpace[3]{new SortingSpace(),new GridSpace(), new GoalSpace(Color.Blue)};
    grid[0].Setup(grid[1], grid[2]);
    var testPiece = new LudoPiece(Color.Red);
    grid[0].pieces[0] = testPiece;
    grid[0].SendPieceForward(grid[0].pieces[0], 1);
    // Then
    Assert.Contains(testPiece, grid[1].pieces);
    Assert.DoesNotContain(testPiece, grid[2].pieces);
}

[Fact]
public void TestMoveTrack_Normal_SRPos()
{
    var grid = new GridSpace[4]{new GridSpace(), new GridSpace(), new GridSpace(), new GridSpace()};
    var player = new Player(Color.Blue);
    var testPiece = new LudoPiece(Color.Blue);
    for(int i = 0; i < 3; i++){
        grid[i].Setup(grid[i+1]);
    }
    player.playerPieces[0] = testPiece;
    grid[0].pieces[0] = testPiece;
    player.lastDieValue = 2;
    player.CalculateMove(2);
    // Then
    Assert.Equal(grid[2],player.projectedPlays[1]);
}


[Theory]
public void TestMapSetup_4PlayerMap_SRPos()
{

}

[Theory]
public void TestMapSetup_5PlayerMap_SRPos()
{
    
}

[Theory]
public void TestPlayerOrder_UniqueRolls_SRPos(){
    // Given

    // When

    // Then
}

[Theory]
public void TestPlayerOrder_DuplicateRolls_SRPos(){
    // Given

    // When

    // Then
}

[Theory]
public void TestPlayerOrder_IsCorrectOrder_SRPos(){
    // Given

    // When

    // Then
}

[Theory]
public void TestPlayerOrder_TripleDiceRoll()
{

}

[Theory]
public void TestDiceRoll_Roll6_SRPos()
{

}

[Theory]
public void TestPieceMove_EnterGoal_SRPos()
{

}

[Theory]
public void TestPieceMove_ReverseMoveInZone_SRPos()
{

}

[Theory]
public void TestPieceMove_PastAlly_SRNeg()
{

}

[Theory]
public void TestPieceMove_PastEnemy_SRPos()
{

}

[Theory]
public void TestPieceMove_EdgeCase1_SRPos()
{
    //This edgecase is for when multiple pieces are close to the goal, but the dice roll is too high, making them block each other
    //The expected result is be to skip the result.
}

[Theory]
public void TestPieceMove_EdgeCase2_SRPos()
{
    //This is the same as before, with a roll of 6, thus continuing the turn
    //The expected result is that the result is skipped, but another roll is provided
}

[Theory]
public void TestPieceMove_ReturnToBase_SRPos()
{

}

[Theory]
public void TestGameLoop_FinishedPlayer_SRNeg()
{

}

[Theory]
public void TestGameLoop_ResultTracking_SRPos()
{

}

[Theory]
public void TestGameLoop_GameRestart_SRPos()
{

}

}