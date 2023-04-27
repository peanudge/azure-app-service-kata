#!/bin/bash

echo "[Restore] project dependencies"
dotnet restore

echo "[Restore] dotnet tools"
dotnet tool restore

echo "[Migration] database migration"
dotnet ef database update
