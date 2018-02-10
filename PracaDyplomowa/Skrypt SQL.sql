CREATE TABLE [dbo].[Syslog] (
    [Id]            INT           NOT NULL,
    [Id_na_stronie] VARCHAR (MAX) NULL,
    [Numer]         VARCHAR (MAX) NULL,
    [Numer2]        VARCHAR (MAX) NULL,
    [Opis]          VARCHAR (MAX) NULL,
    [Rozwiazanie]   VARCHAR (MAX) NULL,
    [Id_strony]     VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);