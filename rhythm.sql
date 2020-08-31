INSERT INTO "Bands" ("Id", "Names", "CountryOfOrigin", "NumberOfMembers",
 "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber"); 
 VALUE (1, 'Green Day', 'USA', 3, 'Greenday.com', "Pop Punk",  'true', 
 'Jeremy Lorenzo', "123-4556-7890");

--     View all the bands
SELECT * From "Bands";

--     Add an album for a band
INSERT INTO "Albums" ("Id", "Title", "IsExplicit", "ReleaseDate")
VALUES (1, 'Dookie','true','1994-02-01' );

--     Let a band go (update isSigned to false)
UPDATE "Bands" SET "IsSigned" = 'false' WHERE "Name" = 'Takking Back Sunday';

--     Resign a band (update isSigned to true)
UPDATE "Bands" SET "IsSigned" = 'true' WHERE "Name" = 'Taking Back Sunday';

-- Given a band name, view all their albums
SELECT “Albums”.“Title”
FROM “Albums”
JOIN “Bands” ON “Albums”.“Id” = “Bands”.“Id”
WHERE “Bands”.“Name” = ‘Green Day’;

-- View all albums ordered by ReleaseDate
SELECT * FROM “Albums” ORDER BY “ReleaseDate”

-- View all bands that are signed
SELECT “Name” FROM “Bands” WHERE “IsSigned” = ‘true’

-- View all bands that are not signed
SELECT “Name” FROM “Bands” WHERE “IsSigned” = ‘false’

-- Create Tables for Band and Album
CREATE TABLE "Bands" ("Id" SERIAL PRIMARY KEY, "Name" TEXT, "CountryOfOrigin" TEXT, "NumberOfMembers" INT, "Website" VARCHAR(20),
 "Style" TEXT, "IsSigned" BOOL, "ContactName" TEXT, "ContactPhoneNumber" VARCHAR(10));

CREATE TABLE "Albums" ("Id" SERIAL PRIMARY KEY, "BandId" INT,
 "Title" TEXT, "IsExplicit" BOOL, "ReleaseDate" DATE);

 -- Add foreign keys to fulfill the following
 -- A Band has many Albums. An Album belongs to one Band.
 ALTER TABLE "Bands" ADD COLUMN "AlbumId" INTEGER NULL REFERENCES "Albums" ("Id");
