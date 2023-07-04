# Entity framework Core

## Definitions des modeles EF Core

EF Core utilise une combinaison de conventions, d'annotations et d'expression de type FLUENT pour construire les modele d'entite au `runtime`. Toutes les operations de code operees sur ce modele a l'execution se refletront sur la BDD.
Une classe `Entity` represente directement la structure de la table. Une instance de cette meme classe representera une ligne de cette meme table.

### Voici une liste non exhaustive de conventions a suivre :

- Le nom de la table est suppose correspondre au nom d'une ppte de type DbSet<T> dans la classe DbContext
- Le noms des colonnes doit matcher le nom des pptes de la classe
- le type string (.NET) doit correspondre au type nvarchar en BDD
- int en .NET -> int en BDD
- La PK doit etre une ppte nommee Id ou ID, ou alors UserId ou UserID pour une entite User. Si le type est integer ou GUID, il sera considerer comme une colonne IDENTITY (un colonne qui obtient une valeur automatiquement a l'insertion)

### Les annotations :

```SQL
CREATE TABLE "Products" (
	"ProductId" INTEGER PRIMARY KEY,
	"ProductName" nvarchar (40) NOT NULL ,
	"SupplierId" "int" NULL ,
```

```C#
[Required]
[StringLength(40)]
public string ProductName {get; set;}

[column(Typename = "money")]
public decimal UnitPrice {get; set;}
```

### La fluent API

On peut utiliser la fluent API a la place des annotations, ou en complement de ces dernieres.

## Creation des modeles

Consignes pour le fichier Category.cs:

- creer trois des quatre pptes (toute sauf Image)
- penser a la PK
- gerer ou penser a une ppte qui gerer la relation one-to-many avec la table Products

### Installation de dotnet-ef tool

Il s'agit d'une extension au .NET cli qui permet d'apporter des fonctionnalites supplementaires lorsqu'on travaille avec EF Core. Elle apporte notammenet des fonctionnalites de design et de migration des BDD. Par defaut cet outil n'est pas installe automatiquement :

- verification d'une installation:
  ``` sh
  dotnet tool list --global
  ````
  - si une ancienne version est installee :
  ``` sh
  dotnet tool uninstall --global dotnet-ef
  ````
- pour installer la derniere version:

  ```sh
  dotnet tool install --global dotnet-ef
  ```

  ### Le processus de `scaffolding`:

  C'est le procede qui permet de creer des classes qui represente le modele d'une BDD existante en utilisant un procede qu'on peut appeler `reverse engineering`.

  Pour cela installer Microsoft.EntityFrameworkCore.Design:

  ```sh
  dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.8
  ```
