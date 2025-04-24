[[Fact]
public void TestPlayerCount_4Players_SRPos()
{
    // Given

    // When

    // Then
}

public void TestPlayerCount_Over4Players_SRPos()
{
    
    // Given

    // When

    // Then       
}

public void TestPlayerCount_Sub4Players_SRPos()
{
    // Given

    // When

    // Then
}

public void TestPlayerCount_0Players_SRPos()
{
    // Given

    // When

    // Then
}

public void TestDiceRoll_SingleRoll_SRPos()
{
    // Given

    // When

    // Then
}

public void TestPieceMove_EmptySingle_SRPos()
{

}

public void TestPieceMove_EmptyMulti_SRPos()
{

}

public void TestPieceMove_AlliedOcc_SRPos()
{

}

public void TestPieceMove_EnemyOcc1_SRPos()
{

}

public void TestPIeceMove_EnemyOcc2_SRPos()
{

}

public void TestPieceMove_IntoTrueZone_SRPos()
{

}

public void TestPieceMove_IntoFalseZone_SRNeg()
{

}

public void TestDiceRoll_MoveTracking_SRPos()
{

}
]

[[Theory]
public void TestMapSetup_4PlayerMap_SRPos()
{

}

public void TestMapSetup_5PlayerMap_SRPos()
{
    
}

public void TestPlayerOrder_UniqueRolls_SRPos(){
    // Given

    // When

    // Then
}

public void TestPlayerOrder_DuplicateRolls_SRPos(){
    // Given

    // When

    // Then
}

public void TestPlayerOrder_IsCorrectOrder_SRPos(){
    // Given

    // When

    // Then
}

public void TestPlayerOrder_TripleDiceRoll()
{

}

public void TestDiceRoll_Roll6_SRPos()
{

}

public void TestPieceMove_EnterGoal_SRPos()
{

}

public void TestPieceMove_ReverseMoveInZone_SRPos()
{

}

public void TestPieceMove_PastAlly_SRNeg()
{

}

public void TestPieceMove_PastEnemy_SRPos()
{

}

public void TestPieceMove_EdgeCase1_SRPos()
{
    //This edgecase is for when multiple pieces are close to the goal, but the dice roll is too high, making them block each other
    //The expected result is be to skip the result.
}

public void TestPieceMove_EdgeCase2_SRPos()
{
    //This is the same as before, with a roll of 6, thus continuing the turn
    //The expected result is that the result is skipped, but another roll is provided
}

public void TestPieceMove_ReturnToBase_SRPos()
{

}

public void TestGameLoop_FinishedPlayer_SRNeg()
{

}

public void TestGameLoop_ResultTracking_SRPos()
{

}

public void TestGameLoop_GameRestart_SRPos()
{

}

]