class OfferItem < ApplicationRecord
  belongs_to :offer
  belongs_to :product

  before_save :set_line_total
  before_create :set_initial_unit_price

  validates :quantity, presence: true, numericality: { greater_than: 0 }
  validates :unit_price, presence: true, numericality: { greater_than_or_equal_to: 0 }

  private

  def set_initial_unit_price
    self.unit_price = product.price if unit_price.nil?
  end

  def set_line_total
    self.line_total = unit_price * quantity
  end
end
