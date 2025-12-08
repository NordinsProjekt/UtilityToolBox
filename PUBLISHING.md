# Publishing to NuGet.org

This guide explains how to publish the UtilityToolBox.Services package to NuGet.org.

## Prerequisites

1. **NuGet.org Account**: Create an account at [nuget.org](https://www.nuget.org/)
2. **API Key**: Generate an API key from your NuGet.org account settings
   - Go to https://www.nuget.org/account/apikeys
   - Click "Create"
   - Give it a name like "GitHub Actions"
   - Set the appropriate scopes (Push new packages and package versions)
   - Copy the generated key

## Setup GitHub Secrets

To enable automated publishing via GitHub Actions:

1. Go to your repository on GitHub
2. Navigate to **Settings** ? **Secrets and variables** ? **Actions**
3. Click **New repository secret**
4. Add the following secret:
   - **Name**: `NUGET_API_KEY`
   - **Value**: Your NuGet.org API key

## Manual Publishing

To manually publish a package:

```bash
# Build and pack
dotnet pack Services/Services.csproj --configuration Release --output ./artifacts

# Publish to NuGet.org
dotnet nuget push ./artifacts/*.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```

## Automated Publishing with GitHub Actions

The workflow in `.github/workflows/build-and-publish.yml` automatically:

1. **On every push/PR**: Builds and tests the package
2. **On version tags**: Publishes to NuGet.org and creates a GitHub Release

### Creating a Release

To trigger an automated release:

```bash
# Update version in Services/Services.csproj
# Then create and push a tag
git tag v1.0.0
git push origin v1.0.0
```

The GitHub Action will:
- Build the project
- Run all tests
- Create the NuGet package
- Publish to NuGet.org
- Create a GitHub Release with the package attached

## Version Management

Update the version in `Services/Services.csproj`:

```xml
<Version>1.0.1</Version>
```

Follow [Semantic Versioning](https://semver.org/):
- **Major** (1.0.0): Breaking changes
- **Minor** (0.1.0): New features, backwards compatible
- **Patch** (0.0.1): Bug fixes, backwards compatible

## Package Verification

After publishing, verify your package at:
- https://www.nuget.org/packages/UtilityToolBox.Services/

It may take a few minutes to appear in search results.

## Testing the Package Locally

Before publishing, test the package locally:

```bash
# Pack the project
dotnet pack Services/Services.csproj --configuration Release --output ./local-packages

# In a test project, add the local package source
dotnet new console -n TestApp
cd TestApp
dotnet nuget add source C:\path\to\UtilityToolBox\local-packages --name LocalPackages
dotnet add package UtilityToolBox.Services --version 1.0.0 --source LocalPackages
```

## Troubleshooting

### Package Already Exists
- You cannot republish the same version
- Increment the version number and try again

### API Key Issues
- Ensure your API key has the correct scopes
- Check that it hasn't expired
- Regenerate if necessary

### Build Failures
- Run `dotnet build` locally first
- Ensure all tests pass
- Check the GitHub Actions logs for details
