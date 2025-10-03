# Application Web - Suivi d’Instances

Cette application web permet de gérer et de suivre des **instances**.  
Les utilisateurs peuvent ajouter de nouvelles instances, suivre leur avancement et, lorsque la tâche est presque terminée, envoyer un email automatique au responsable de la tâche.

---

## 🚀 Fonctionnalités
- Création et suivi d’instances  
- Gestion de l’avancement des tâches  
- Notification par email au responsable  
- Interface web simple et intuitive  
- Compte administrateur intégré  

---

## 🛠️ Technologies utilisées
- ASP.NET (.NET Framework)  
- C#  
- SQL Server  
- HTML, CSS, JavaScript  

---

## ⚙️ Installation

### 1. Base de données
1. Ouvrir le fichier **projet.sql** dans SQL Server Management Studio  
2. Exécuter le script pour créer la base et les tables nécessaires  

### 2. Configuration
1. Ouvrir le fichier **web.config**  
2. Modifier la section `connectionStrings` avec ta propre chaîne de connexion SQL Server. Exemple :  

```xml
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=SuiviInstancesDB;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>

