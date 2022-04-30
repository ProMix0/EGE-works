using N19_21;

PositionsTable table = new(5, 1, 65, new()
{
    a => a + 1,
    a => a * 2
});

