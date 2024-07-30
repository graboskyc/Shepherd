from fastapi import FastAPI, Request
from fastapi.responses import HTMLResponse
from fastapi.templating import Jinja2Templates
from fastapi import APIRouter

router = APIRouter()
templates = Jinja2Templates(directory="templates")

@router.get("/", response_class=HTMLResponse)
@router.get("/home", response_class=HTMLResponse)
async def index(request: Request):
    return templates.TemplateResponse(request=request, name="home/home.html")

@router.get("/about", response_class=HTMLResponse)
async def about(request: Request):
    return templates.TemplateResponse(request=request, name="home/about.html")

@router.get("/pricing", response_class=HTMLResponse)
async def about(request: Request):
    return templates.TemplateResponse(request=request, name="home/pricing.html")