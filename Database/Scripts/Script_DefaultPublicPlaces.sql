IF OBJECT_ID(N'dbo.PublicPlace', N'U') IS NOT NULL
BEGIN
    INSERT INTO [PublicPlace](
        PlaceName
    )
    VALUES
    ('Avenida'),
    ('Rua'),
    ('Travessa'),
    ('Via'),
    ('Vale'),
    ('Parque'),
    ('Esplanada'),
    ('Rodovia')
END