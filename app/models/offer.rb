class Offer < ApplicationRecord
  belongs_to :company
  has_many :offer_items, dependent: :destroy

  def recalculate_totals!
  net = 0
  vat = 0

  offer_items.includes(:product).each do |item|
    next unless item.product.present? # güvenlik önlemi

    line_net = item.line_total
    line_vat = line_net * (item.product.vat_rate.to_f / 100)

    net += line_net
    vat += line_vat
  end

  update!(
    net_total:   net.round(2),
    vat_total:   vat.round(2),
    gross_total: (net + vat).round(2)
  )
  end
end
