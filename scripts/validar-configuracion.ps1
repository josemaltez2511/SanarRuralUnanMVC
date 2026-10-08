# =============================================================================
# Script de Proteccion: Validacion de Configuracion Local (Sanar Rural UNAN)
# =============================================================================
# Este script verifica que 'App.config' (en cualquier variante de mayúsculas/
# minúsculas) no se encuentre versionado en Git, ni en staged, ni introducido
# mediante archivo nuevo, modificación, rename o copia en un commit o PR.
# =============================================================================

$ErrorActionPreference = "Stop"

# 1. Verificar existencia de la plantilla obligatoria App.config.example
if (-not (Test-Path "App.config.example")) {
    Write-Host ""
    Write-Host "[ERROR DE CONFIGURACION] No se encontro la plantilla requerida 'App.config.example'." -ForegroundColor Red
    Write-Host "El repositorio debe incluir siempre 'App.config.example' como plantilla para los desarrolladores." -ForegroundColor Yellow
    Write-Host ""
    exit 1
}

# 2. Verificar que .gitignore contenga la regla para App.config (insensible a mayúsculas)
if (Test-Path ".gitignore") {
    $gitignoreContent = Get-Content ".gitignore" -Raw
    if ($gitignoreContent -notmatch "(?mi)^(\[Aa\]pp|app)\.config\b") {
        Write-Host ""
        Write-Host "[ERROR DE CONFIGURACION] '.gitignore' no contiene la regla para excluir 'App.config'." -ForegroundColor Red
        Write-Host "Agregue 'App.config' al archivo .gitignore." -ForegroundColor Yellow
        Write-Host ""
        exit 1
    }
}

# 3. Verificar si App.config esta en el indice de Git (archivos rastreados, cualquier variante)
$archivosRastreados = git ls-files | Where-Object { $_ -match "(?i)(^|[/\\])app\.config$" }
if ($archivosRastreados) {
    Write-Host ""
    Write-Host "[ERROR DE CONFIGURACION] Se detecto 'App.config' en el indice de Git: $archivosRastreados" -ForegroundColor Red
    Write-Host "El archivo 'App.config' contiene configuraciones y credenciales locales de base de datos." -ForegroundColor Yellow
    Write-Host "NUNCA debe ser versionado en el repositorio." -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Solucion recomendada:" -ForegroundColor Cyan
    Write-Host "  1. Ejecute: git rm --cached App.config" -ForegroundColor Cyan
    Write-Host "  2. Utilice 'App.config.example' como plantilla para documentar cambios de estructura." -ForegroundColor Cyan
    Write-Host ""
    exit 1
}

# 4. Verificar si App.config esta en staged para commit (nuevo, modificado, renombrado o copiado)
$stagedViolaciones = git diff --name-status -M -C --cached | Where-Object {
    ($_ -match "(?i)[\s\t]app\.config$") -and -not ($_ -match "(?i)^d\s+")
}
if ($stagedViolaciones) {
    Write-Host ""
    Write-Host "[ERROR DE CONFIGURACION] Se intento agregar, modificar, renombrar o copiar 'App.config' en staged:" -ForegroundColor Red
    $stagedViolaciones | ForEach-Object { Write-Host "  $_" -ForegroundColor Red }
    Write-Host "El archivo 'App.config' no debe ser incluido en ningun commit." -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Solucion recomendada:" -ForegroundColor Cyan
    Write-Host "  Ejecute: git reset HEAD App.config" -ForegroundColor Cyan
    Write-Host ""
    exit 1
}

# 5. Comprobacion para entornos de CI / Pull Requests (GitHub Actions)
if ($env:GITHUB_ACTIONS -eq "true") {
    if ($env:GITHUB_BASE_REF) {
        # Validar en contexto de Pull Request contra la rama destino (nuevo, modificado, rename, copia)
        $diffPR = git diff --name-status -M -C "origin/$($env:GITHUB_BASE_REF)...HEAD" | Where-Object {
            ($_ -match "(?i)[\s\t]app\.config$") -and -not ($_ -match "(?i)^d\s+")
        }
        if ($diffPR) {
            Write-Host ""
            Write-Host "[ERROR DE CONFIGURACION EN PR] El Pull Request introduce o modifica 'App.config':" -ForegroundColor Red
            $diffPR | ForEach-Object { Write-Host "  $_" -ForegroundColor Red }
            Write-Host "Por favor remueva 'App.config' de la rama del Pull Request." -ForegroundColor Yellow
            Write-Host ""
            exit 1
        }
    }
    elseif ($env:GITHUB_EVENT_NAME -eq "push") {
        # Validar en contexto de push directo (nuevo, modificado, rename, copia)
        $diffPush = git diff-tree --no-commit-id --name-status -M -C -r HEAD | Where-Object {
            ($_ -match "(?i)[\s\t]app\.config$") -and -not ($_ -match "(?i)^d\s+")
        }
        if ($diffPush) {
            Write-Host ""
            Write-Host "[ERROR DE CONFIGURACION EN PUSH] El commit introdujo 'App.config' al repositorio:" -ForegroundColor Red
            $diffPush | ForEach-Object { Write-Host "  $_" -ForegroundColor Red }
            Write-Host ""
            exit 1
        }
    }
}

Write-Host "[OK] Verificacion exitosa: 'App.config' esta excluido del repositorio y 'App.config.example' esta presente." -ForegroundColor Green
exit 0
