# Guide de Dépannage - Erreurs de Compilation

## Problème : "Le nom de type ou d'espace de noms 'Service1Client' est introuvable"

### Solutions à Essayer dans l'Ordre :

#### 1. Vérifier l'Ordre de Compilation

**Problème :** Le projet `AppGroupe2` essaie de compiler avant `MetierRvMedical`.

**Solution :**
```bash
# Utiliser le script de compilation
build.bat
```

Ou manuellement :
1. Compiler `MetierRvMedical` en premier
2. Puis compiler `AppGroupe2`

#### 2. Vérifier les Références de Projet

**Problème :** La référence au projet `MetierRvMedical` est manquante ou incorrecte.

**Solution :**
- Ouvrir `AppGroupe2.csproj`
- Vérifier que la référence existe :
```xml
<ProjectReference Include="..\MetierRvMedical\MetierRvMedical.csproj">
  <Project>{0EEDA160-BE94-4532-AE81-59F2D8C2AB97}</Project>
  <Name>MetierRvMedical</Name>
</ProjectReference>
```

#### 3. Nettoyer et Recompiler

**Problème :** Fichiers de compilation obsolètes.

**Solution :**
```bash
# Nettoyer tous les projets
msbuild /t:Clean

# Recompiler dans l'ordre
msbuild MetierRvMedical\MetierRvMedical.csproj
msbuild AppGroupe2\AppGroupe2.csproj
```

#### 4. Vérifier les Namespaces

**Problème :** Namespaces incorrects dans le code.

**Solution :**
- Utiliser `AppGroupe2.ServiceMetier.Service1Client` au lieu de `ServiceMetier.Service1Client`
- Ajouter `using MaterielRvMedical.Model;` dans les fichiers

#### 5. Vérifier les Directives Using

**Problème :** Directives using manquantes.

**Solution :**
Ajouter dans tous les fichiers qui utilisent le service :
```csharp
using AppGroupe2.ServiceMetier;
using MaterielRvMedical.Model;
using MetierRvMedical;
```

#### 6. Vérifier la Configuration WCF

**Problème :** Configuration WCF manquante.

**Solution :**
Vérifier que `App.config` contient :
```xml
<system.serviceModel>
  <bindings>
    <basicHttpBinding>
      <binding name="BasicHttpBinding_IService1" maxBufferSize="2147483647" maxReceivedMessageSize="2147483647">
        <security mode="None" />
      </binding>
    </basicHttpBinding>
  </bindings>
  <client>
    <endpoint address="http://localhost:8733/Design_Time_Addresses/MetierRvMedical/Service1/" 
              binding="basicHttpBinding" 
              bindingConfiguration="BasicHttpBinding_IService1" 
              contract="MetierRvMedical.IService1" 
              name="BasicHttpBinding_IService1" />
  </client>
</system.serviceModel>
```

#### 7. Test de Connexion

**Problème :** Le service WCF n'est pas démarré.

**Solution :**
```csharp
// Utiliser la classe de test
TestCompilation.TestServiceClientCreation();
TestCompilation.TestServiceClientFull();
```

### Fichiers de Test Créés :

1. **`SimpleServiceClient.cs`** - Client WCF simple pour tester la connexion
2. **`TestCompilation.cs`** - Tests de compilation et de connexion
3. **`build.bat`** - Script de compilation automatique

### Ordre de Résolution Recommandé :

1. ✅ Exécuter `build.bat`
2. ✅ Vérifier les références de projet
3. ✅ Nettoyer et recompiler
4. ✅ Vérifier les namespaces
5. ✅ Tester la connexion

### Messages d'Erreur Courants :

- **"Service1Client introuvable"** → Vérifier l'ordre de compilation
- **"IService1 introuvable"** → Vérifier la référence au projet MetierRvMedical
- **"RendezVous introuvable"** → Ajouter `using MaterielRvMedical.Model;`
- **"Erreur de connexion"** → Démarrer le service WCF

### Commandes Utiles :

```bash
# Compilation complète
build.bat

# Nettoyage
msbuild /t:Clean

# Compilation individuelle
msbuild MetierRvMedical\MetierRvMedical.csproj
msbuild AppGroupe2\AppGroupe2.csproj
``` 