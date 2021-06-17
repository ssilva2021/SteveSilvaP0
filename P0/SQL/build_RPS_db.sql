CREATE TABLE Player (
    PlayerID int IDENTITY(1,1) NOT NULL,
    PlayerFname varchar(64),
    PlayerLname varchar(64),
    PlayerAge int,
    Country varchar(64),
    Street varchar(64),
    State varchar(2),
    PRIMARY KEY (PlayerID)
); 

-- public int PlayerId { get; set; }
--         public string PlayerFname { get; set; }
--         public string PlayerLname { get; set; }
--         public int? PlayerAge { get; set; }
--         public string Country { get; set; }
--         public string Street { get; set; }
--         public string City { get; set; }
--         public string State { get; set; }
--         public DateTime? DateAdded { get; set; }

CREATE TABLE Game (
    GameID int IDENTITY(1,1) NOT NULL,
    Player1 int,
    Player2 int,
    GameWinner int,
    DateAdded datetime not null default(current_timestamp),
    PRIMARY KEY (GameID),
    FOREIGN KEY (Player1) REFERENCES Player(PlayerID),
    FOREIGN KEY (Player2) REFERENCES Player(PlayerID),
    FOREIGN KEY (GameWinner) REFERENCES Player(PlayerID)

);

--    public int GameId { get; set; }
--         public int Player1 { get; set; }
--         public int Player2 { get; set; }
--         public int GameWinner { get; set; }
--         public DateTime? DateAdded { get; set; }

CREATE TABLE Round (
    RoundID int IDENTITY(1,1) NOT NULL,
    Player1Choice int,
    Player2Choice int,
    GameID int,
    DateAdded datetime not null default(current_timestamp),
    PRIMARY KEY (RoundID),
    FOREIGN KEY (GameID) REFERENCES Game(GameID)

);
-- public partial class Round
--     {
--         public int RoundId { get; set; }
--         public int Player1Choice { get; set; }
--         public int Player2Choice { get; set; }
--         public int GameId { get; set; }
--         public DateTime? DateAdded { get; set; }

--         public virtual Game Game { get; set; }
--         public virtual Choice Player1ChoiceNavigation { get; set; }
--         public virtual Choice Player2ChoiceNavigation { get; set; }
--     }


-- This table contains the choices the player has for each round
        -- public Choice()
        -- {
        --     RoundPlayer1ChoiceNavigations = new HashSet<Round>();
        --     RoundPlayer2ChoiceNavigations = new HashSet<Round>();
        -- }