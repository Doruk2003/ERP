Rails.application.routes.draw do
  get "companies/index"
  get "companies/show"
  get "companies/new"
  get "companies/edit"
  get "offers/index"
  get "offers/show"
  get "offers/new"
  get "offers/edit"
  get "products/index"
  get "products/show"
  get "products/new"
  get "products/edit"
  root "pages#home"

  resources :products
  resources :offers
  resources :companies
end
