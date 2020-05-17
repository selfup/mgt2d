# Mono Game Template 2D

Just trying to figure out how this all works.

### Setup

#### deps

Make sure to have dotnet 3.1 installed: https://dotnet.microsoft.com/download

Mono will be required for the build pipeline: https://www.mono-project.com/docs/getting-started/install/

If on macOS and using bash, update your PATH in your `$HOME/.bash_profile`:

```bash
# Mono path - MonoGame dependency
export PATH=/Library/Frameworks/Mono.framework/Versions/Current/bin/:${PATH}
```

Now reload your bash_profile: `source $HOME/.bash_profile`

#### install libraries

In this repo: `dotnet restore`

### Run

In this repo: `dotnet run`

### Watch 

In this repo: `dotnet watch run`
