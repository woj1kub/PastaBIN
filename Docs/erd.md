---
title: PastaBIN
---
erDiagram
    Cook {
        INT ID PK
        VARCHAR Login
        VARCHAR Password
        VARCHAR Email
    }
    PastaInfo {
        INT ID PK
        VARCHAR Key
        DATETIME CreationDate
        DATETIME DeleteTime
        BIT IsActive
    }
    CookedPastaText {
        INT ID PK
        INT IDPastaText FK
        INT IDUser FK
    }
    PastaImg {
        INT ID PK
        INT IDPastaInfo FK
        BLOB PastaImg
    }
    CookedPastaImg {
        INT ID PK
        INT IDPastaImg FK
        INT IDUser FK
    }
    PastaText {
        INT ID PK
        INT IDPastaInfo FK
        TEXT Pasta
    }



    PastaInfo ||--o{ PastaText : ""
    PastaInfo ||--o{ PastaImg : ""
    PastaText ||--o{ CookedPastaText : ""
    Cook ||--o{ CookedPastaImg : ""
    Cook ||--o{ CookedPastaText : ""
    PastaImg ||--o{ CookedPastaImg : ""
