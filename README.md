# Project .NET Framework

* Naam: Sam Rotthier
* Studentennummer: 0162653-81
* Academiejaar: 23-24
* Klasgroep: TIFL02
* Onderwerp: Monster *-1 Player \*-\* Guild

---
- Solution name: MedievalMMO
    - Console Application project: CA

## Sprint 3
### Beide zoekcriteria ingevuld
```sql
SELECT "g"."GuildId", "g"."GuildLevel", "g"."GuildMadeBy", "g"."GuildMadeOn", "g"."GuildName"
FROM "Guilds" AS "g"
WHERE (@__upperGuildName_0 = '' OR instr(upper("g"."GuildName"), @__upperGuildName_0) > 0) AND "g"."GuildLevel" = @__guildLevel_Value_1
```

### Enkel zoeken op naam
```sql
SELECT "g"."GuildId", "g"."GuildLevel", "g"."GuildMadeBy", "g"."GuildMadeOn", "g"."GuildName"
FROM "Guilds" AS "g"
WHERE @__upperGuildName_0 = '' OR instr(upper("g"."GuildName"), @__upperGuildName_0) > 0
```

### Enkel zoeken op level
```sql
SELECT "g"."GuildId", "g"."GuildLevel", "g"."GuildMadeBy", "g"."GuildMadeOn", "g"."GuildName"
FROM "Guilds" AS "g"
WHERE "g"."GuildLevel" = @__guildLevel_Value_0
```

### Beide zoekcriteria leeg
```sql
SELECT "g"."GuildId", "g"."GuildLevel", "g"."GuildMadeBy", "g"."GuildMadeOn", "g"."GuildName"
FROM "Guilds" AS "g"
```