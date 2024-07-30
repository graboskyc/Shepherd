from fastapi import FastAPI, Request
from fastapi.staticfiles import StaticFiles
from fastapi.exceptions import HTTPException
from fastapi.templating import Jinja2Templates
from .routers import home

async def not_found_error(request: Request, exc: HTTPException):
    return templates.TemplateResponse('home/404.html', {'request': request}, status_code=404)


async def internal_error(request: Request, exc: HTTPException):
    return templates.TemplateResponse('home/500.html', {'request': request}, status_code=500)

    
templates = Jinja2Templates(directory='templates')

exception_handlers = {
    404: not_found_error,
    500: internal_error
}

app = FastAPI(exception_handlers=exception_handlers)
app.mount("/static", StaticFiles(directory="static", html=True), name="static")

app.include_router(home.router)