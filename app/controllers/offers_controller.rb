class OffersController < ApplicationController
  def index
    @offers = Offer.all
  end

  def show
    @offer = Offer.find(params[:id])
  end

  def new
    @offer = Offer.new
    @offer.offer_items.build
  end

  def step1
  @offer = Offer.new
  end

def create_step1
  @offer = Offer.new(offer_params)

  if @offer.save
    redirect_to edit_offer_path(@offer), notice: "Teklif başarıyla oluşturuldu."
  else
    render :step1
  end
end

def step2
  @offer = Offer.find(params[:id])
end

def update_step2
  @offer = Offer.find(params[:id])

  if @offer.update(offer_params)
    @offer.recalculate_totals!
    redirect_to @offer, notice: "Teklif başarıyla güncellendi."
  else
    render :step2
  end
end

  def edit
    @offer = Offer.find(params[:id])
  end

  def create
    @offer = Offer.new(offer_params)

    if @offer.save
      redirect_to @offer, notice: "Teklif başarıyla oluşturuldu."
    else
      render :new
    end
  end

  def update
    @offer = Offer.find(params[:id])

    if @offer.update(offer_params)
      redirect_to @offer, notice: "Teklif başarıyla güncellendi."
    else
      render :edit
    end
  end

  def destroy
    @offer = Offer.find(params[:id])
    @offer.destroy
    redirect_to offers_url, notice: "Teklif başarıyla silindi."
  end

  private

  def offer_params
    params.require(:offer).permit(:offer_number, :currency, :company_id, offer_items_attributes: [ :id, :product_id, :quantity, :unit_price, :_destroy ])
  end
end
